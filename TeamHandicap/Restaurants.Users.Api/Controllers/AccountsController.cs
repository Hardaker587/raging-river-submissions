using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurants.Users.Api.Authentication;
using Restaurants.Users.Api.Extensions;
using Restaurants.Users.Api.Helpers;
using Restaurants.Users.Api.Models.EntityModels;
using Restaurants.Users.Api.Models.RequestModels;

namespace Restaurants.Users.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUserModel> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly IJwtFactory _jwtFactory;
        private readonly IConfiguration _appConfig;

        public AccountsController(
            UserManager<AppUserModel> userManager, AppDbContext appDbContext,
            IJwtFactory jwtFactory, IConfiguration appConfig
        )
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _jwtFactory = jwtFactory;
            _appConfig = appConfig;
        }

        /// <summary>
        /// Registers a new user on the system and returns a JWT token for this user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A JWT token for the newly created user.</returns>
        [AllowAnonymous, HttpPost("register")]
        public async Task<IActionResult> UserRegistration([FromBody] NewUserRequestModel model)
        {
            if (string.IsNullOrWhiteSpace(model.EmailAddress))
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "Email address is required", ModelState));
            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "Password is required", ModelState));
            }

            var newUser = new AppUserModel
            {
                UserName = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.EmailAddress,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(ErrorHelper.AddErrorsToModelState(result, ModelState));
            }

            return Ok(await _userManager.GenerateJwtAsync(newUser, _jwtFactory, _appDbContext));
        }

        /// <summary>
        /// Checks if the provided credentials match those of a user in the database, 
        /// and returns a JWT token for accessing protected endpoints if it does.
        /// </summary>
        /// <param name="credentials">Login credentials.</param>
        /// <returns>Returns an object {token: XXX} where XXX is a Base64 encoded JSON Web Token (JWT).</returns>
        [AllowAnonymous, HttpPost("login")]
        public async Task<IActionResult> AttemptLogin([FromBody]CredentialsRequestModel credentials)
        {
            var user = await _userManager.CheckCredentialsAsync(credentials.UserName, credentials.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            user.LastLoggedInAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            return Ok(await _userManager.GenerateJwtAsync(user, _jwtFactory, _appDbContext));
        }

        /// <summary>
        /// Given a valid password reset token, this method will reset the
        /// user's password to the specified NewPassword.
        /// </summary>
        /// <param name="model">A password reset token along with the desired new password.</param>
        /// <returns>Returns a JWT token if the password reset was successful.</returns>
        [AllowAnonymous, HttpPost("reset-password")]
        public async Task<IActionResult> ResetUserPassword([FromBody]PasswordResetRequestModel model)
        {
            var user = await _appDbContext.Users
                .SingleOrDefaultAsync(u => u.ResetPwdToken == model.Token);
            if (user == null)
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "Invalid password reset token.", ModelState));
            }

            if (user.ResetPwdExpDate < DateTime.UtcNow)
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "Token has already expired.", ModelState));
            }
                
            user.ResetPwdToken = null;
            user.ResetPwdSentCount = 0;

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(ErrorHelper.AddErrorsToModelState(result, ModelState));
            }

            return Ok(await _userManager.GenerateJwtAsync(user, _jwtFactory, _appDbContext));
        }

        [AllowAnonymous, HttpPost("forgot-password/{userName}"), HttpGet("forgot-password/{userName}")]
        public async Task<IActionResult> ForgotUserPassword(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "A valid UserName should be provided as the last component of the route.", ModelState));
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound();
            }

            // You can use _userManager.GetOrGeneratePwdResetTokenAsync to get a password reset
            // token and send it to the user in which ever way the client dictates.
            if (!(await _userManager.SendResetPasswordEmailAsync(user, _appConfig)))
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "Failed to send password reset email. This could be because the send count limit was reached.", ModelState));
            }

            return Ok();
        }

        /// <summary>
        /// Upload or replace user's avatar image.
        /// </summary>
        /// <param name="file">Avatar file to be uploaded</param>
        /// <returns>New JWT token with updated avatar id.</returns>
        [Authorize, HttpPost("avatar")]
        public async Task<IActionResult> UploadAvatar(IFormFile file)
        {
            var user = await AuthHelper.GetCurrentUserAsync(_appDbContext, HttpContext);
            if (user == null)
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "Unknown user account - Invalid JWT.", ModelState));
            }

            try
            {
                await AvatarHelper.UploadAvatar(file, user, _appDbContext, _appConfig);
                return Ok(await _userManager.GenerateJwtAsync(user, _jwtFactory, _appDbContext));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", ex.Message, ModelState));
            }
        }
    }
}