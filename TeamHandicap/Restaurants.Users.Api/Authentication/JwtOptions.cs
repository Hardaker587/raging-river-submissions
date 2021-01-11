using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Restaurants.Users.Api.Authentication
{
    public class JwtOptions
    {
        /// <summary>
        /// "iss" (Issuer) Claim - Identifies the principal that issued the JWT.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// "sub" (Subject) Claim - Identifies the principal that is the subject of the JWT.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// "aud" (Audience) Claim - Identifies the recipients that the JWT is intended for.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// "exp" (Expiration Time) Claim - Identifies the expiration time on or after which the JWT MUST NOT be accepted for processing.
        /// </summary>
        public DateTime Expiration => IssuedAt.Add(ValidFor);

        /// <summary>
        /// "nbf" (Not Before) Claim - Identifies the time before which the JWT MUST NOT be accepted for processing.
        /// </summary>
        public DateTime NotBefore => DateTime.UtcNow;

        /// <summary>
        /// "iat" (Issued At) Claim - Identifies the time at which the JWT was issued.
        /// </summary>
        public DateTime IssuedAt => DateTime.UtcNow;

        /// <summary>
        /// Set the timespan the token will be valid for (default is one day)
        /// </summary>
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromHours(24);

        /// <summary>
        /// "jti" (JWT ID) Claim (default ID is a GUID)
        /// </summary>
        public Func<Task<string>> JtiGenerator => () => Task.FromResult(Guid.NewGuid().ToString());

        /// <summary>
        /// The signing key to use when generating tokens.
        /// </summary>
        public SigningCredentials SecretKey { get; set; }
    }
}
