using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurants.Users.Api.Helpers
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Generates a random string that conforms to the specified constraints.
        /// </summary>
        /// <param name="opts">The constraints to which the random string should conform.</param>
        /// <returns>Returns a randomly generated string that conforms to the specified criteria.</returns>
        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null)
            {
                opts = new PasswordOptions()
                {
                    RequiredLength = 16,
                    RequiredUniqueChars = 4,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = true,
                    RequireUppercase = true
                };
            }

            string[] charGroups = new[]
            {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                "abcdefghijkmnopqrstuvwxyz",    // lowercase
                "0123456789"                   // digits
                // "!@$?_-"                        // non-alphanumeric
            };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    charGroups[0][rand.Next(0, charGroups[0].Length)]);
            }

            if (opts.RequireLowercase)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    charGroups[1][rand.Next(0, charGroups[1].Length)]);
            }

            if (opts.RequireDigit)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    charGroups[2][rand.Next(0, charGroups[2].Length)]);
            }

            /* if (opts.RequireNonAlphanumeric)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    charGroups[3][rand.Next(0, charGroups[3].Length)]);
            }*/

            while (chars.Count < opts.RequiredLength || chars.Distinct().Count() < opts.RequiredUniqueChars)
            {
                string charGroup = charGroups[rand.Next(0, charGroups.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    charGroup[rand.Next(0, charGroup.Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}
