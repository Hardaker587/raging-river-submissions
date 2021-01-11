using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restaurants.Users.Api.Authentication
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedTokenAsync(string userName, IEnumerable<Claim> claims);
    }
}
