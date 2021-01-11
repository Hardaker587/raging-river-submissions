using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Restaurants.Users.Api.Models.EntityModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restaurants.Users.Api.Helpers
{
    public static class AuthHelper
    {
        public static async Task<AppUserModel> GetCurrentUserAsync(AppDbContext dbContext, HttpContext httpContext)
        {
            AppUserModel user = null;

            var normalisedUserName = GetUserName(httpContext)?.ToUpper();
            if (normalisedUserName != null)
            {
                user = await dbContext.Users
                    .Include(u => u.AvatarFile)
                    .Include(u => u.Favourites)
                    // Include other navigation properties here
                    .SingleOrDefaultAsync(u => u.NormalizedUserName == normalisedUserName);
            }

            return user;
        }

        public static string GetUserName(HttpContext httpContext)
        {
            var identity = httpContext?.User?.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }

            return null;
        }

        public static string GetClaimValue(HttpContext httpContext, string claimKey)
        {
            var identity = httpContext?.User?.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return identity.FindFirst(claimKey)?.Value;
            }

            return null;
        }
    }
}
