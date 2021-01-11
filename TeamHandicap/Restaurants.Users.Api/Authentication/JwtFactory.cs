using Microsoft.Extensions.Options;
using Restaurants.Users.Api.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restaurants.Users.Api.Authentication
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtOptions _jwtOptions;

        public JwtFactory(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);
        }

        /// <summary>
        /// Generates and encodes a JWT token with the provided user name and claims in its payload. 
        /// The token is generated based on the configurations specified in the global JwtOptions instance.
        /// </summary>
        /// <param name="userName">The username of the user for which the token should be generated.</param>
        /// <param name="claims">A list of claims defined for the user for which the token should be generated.</param>
        /// <returns>A Base64 encoded JWT token with the provided arguments as payload.</returns>
        public async Task<string> GenerateEncodedTokenAsync(string userName, IEnumerable<Claim> claims)
        {
            // Specify the basic set of claims relevant to this application.
            var combinedClaims = new List<Claim>()
            {
                 new Claim(JwtRegisteredClaimNames.Sub, userName),
                 new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.Iat, _jwtOptions.IssuedAt.ToUnixTimestamp().ToString(), ClaimValueTypes.Integer64)
             };

            // Add other claims.
            combinedClaims.AddRange(claims);

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: combinedClaims,
                notBefore: _jwtOptions.NotBefore,
                expires: _jwtOptions.Expiration,
                signingCredentials: _jwtOptions.SecretKey
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }


        /// <summary>
        /// Performs basic validation on a JwtOptions instance to ensure that valid JWT tokens will be generated.
        /// An exception will be thrown if the provided JwtOptions instance is invalid.
        /// </summary>
        /// <param name="options">JwtOptions instance to validate</param>
        private static void ThrowIfInvalidOptions(JwtOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (options.SecretKey == null) throw new ArgumentNullException(nameof(JwtOptions.SecretKey));
            if (options.JtiGenerator == null) throw new ArgumentNullException(nameof(JwtOptions.JtiGenerator));
            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtOptions.ValidFor));
            }
        }
    }
}
