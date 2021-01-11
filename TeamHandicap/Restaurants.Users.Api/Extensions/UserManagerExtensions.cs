using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Restaurants.Users.Api.Authentication;
using Restaurants.Users.Api.Helpers;
using Restaurants.Users.Api.Models.EntityModels;
using Restaurants.Users.Api.Models.ResponseModels;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restaurants.Users.Api.Extensions
{
    public static class UserManagerExtensions
    {
        /// <summary>
        /// Checks if the provided credentials match those of a user on the system.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="password">Plain text password.</param>
        /// <returns>Returns the matching user, otherwise returns null.</returns>
        public static async Task<AppUserModel> CheckCredentialsAsync(this UserManager<AppUserModel> userManager, string userName, string password)
        {
            var userToVerify = await userManager.FindByNameAsync(userName);
            if (userToVerify != null && await userManager.CheckPasswordAsync(userToVerify, password))
            {
                return userToVerify;
            }

            return null;
        }

        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="user">The user for which the token should be generated.</param>
        /// <param name="jwtFactory">An instance of the JwtFactory.</param>
        /// <param name="dbContext">An instance of the AppDbContext for retrieving additional user info.</param>
        /// <returns>A JWT token.</returns>
        public static async Task<JwtResponseModel> GenerateJwtAsync(this UserManager<AppUserModel> userManager, AppUserModel user, IJwtFactory jwtFactory, AppDbContext dbContext)
        {
            _ = dbContext; // Although dbContext is not used now, it will be when custom claims are required.

            var claims = await userManager.GetClaimsAsync(user);
            if (!string.IsNullOrWhiteSpace(user.FirstName))
                claims.Add(new Claim(Constants.ClaimTypes.FIRST_NAME, user.FirstName));
            if (!string.IsNullOrWhiteSpace(user.AvatarFileId))
                claims.Add(new Claim(Constants.ClaimTypes.AVATAR_ID, user.AvatarFileId));
            // Add any additional custom claims here, e.g., email address, if the user has ever logged in before etc.

            var jwt = new JwtResponseModel 
            { 
                Token = await jwtFactory.GenerateEncodedTokenAsync(user.UserName, claims)
            };

            return jwt;
        }

        /// <summary>
        /// Retrieves the stored value of a specified claim.
        /// </summary>
        /// <param name="user">The AppUser instance to retrieve the claim value for.</param>
        /// <param name="key">The identifier of the claim to retrieve the value for.</param>
        /// <returns>Returns the string representation of the desired claim. If the claim does not exist for the specified user, returns NULL</returns>
        public static async Task<string> GetClaimValueAsync(this UserManager<AppUserModel> userManager, AppUserModel user, string key)
        {
            var claims = await userManager.GetClaimsAsync(user);
            var claim = claims.FirstOrDefault(c => c.Type == key);
            if (claim != null)
            {
                return claim.Value;
            }

            return null;
        }

        /// <summary>
        /// If a claim with the specified claim key already exists for the specified user, the first occurence of such existing claims
        /// is updated with the new value; otherwise, a new claim with the specified value is created for the user.
        /// </summary>
        /// <param name="user">The AppUser instance for which the claim should be added or updated.</param>
        /// <param name="key">The identifier of the claim that should be added or updated.</param>
        /// <param name="value">The desired value of the specified claim.</param>
        public static async Task AddUpdateClaimAsync(this UserManager<AppUserModel> userManager, AppUserModel user, string key, string value)
        {
            var claims = await userManager.GetClaimsAsync(user);
            var existingClaim = claims.FirstOrDefault(c => c.Type == key);
            var newClaim = new Claim(key, value);
            if (existingClaim != null)
            {
                await userManager.ReplaceClaimAsync(user, existingClaim, newClaim);
            }
            else
            {
                await userManager.AddClaimAsync(user, newClaim);
            }
        }

        /// <summary>
        /// Gets a password reset token for a user instance. If the user’s token is null or expired, a new
        /// token is generated and the ResetPwdToken, ResetPwdExpDate and ResetPwdSentCount fields are updated accordingly.
        /// </summary>
        /// <param name="user">The user instance to get or generate an password reset token for.</param>
        /// <param name="pwdOpts">The constraints to which the reset token should conform to.</param>
        /// <param name="minTimeRemaining">The minimum time period for which the token should still be valid for.</param>
        /// <returns>An existing or newly generated password reset token for the provided user instance.</returns>
        public async static Task<string> GetOrGeneratePwdResetTokenAsync(this UserManager<AppUserModel> userManager, AppUserModel user, PasswordOptions pwdOpts, TimeSpan minTimeRemaining)
        {
            if (user.ResetPwdToken == null || DateTime.UtcNow.Add(minTimeRemaining) > user.ResetPwdExpDate)
            {
                // Generate a new reset password token
                var pwdToken = PasswordHelper.GenerateRandomPassword(pwdOpts);

                user.ResetPwdToken = pwdToken;
                user.ResetPwdSentCount = 0;
                user.ResetPwdExpDate = DateTime.UtcNow.Add(
                    TimeSpan.FromHours(24) > minTimeRemaining ? TimeSpan.FromHours(24) : minTimeRemaining
                );
            }

            await userManager.UpdateAsync(user);

            return user.ResetPwdToken;
        }

        public static async Task<bool> SendResetPasswordEmailAsync(this UserManager<AppUserModel> userManager, AppUserModel user, IConfiguration appConfig)
        {
            var pwdOptions = new PasswordOptions()
            {
                RequiredLength = 32,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            // Get a password reset token with at least 4 hours before expiration.
            var token = await userManager.GetOrGeneratePwdResetTokenAsync(user, pwdOptions, TimeSpan.FromHours(4));

            if (user.ResetPwdSentCount < 3)
            {
                if (EmailHelper.SendPasswordResetLink(appConfig, user, token))
                {
                    ++user.ResetPwdSentCount;
                    await userManager.UpdateAsync(user);
                    return true;
                }
            }

            return false;
        }
    }
}
