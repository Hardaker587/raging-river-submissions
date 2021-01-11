using System;

namespace Restaurants.Users.Api.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts DateTime instance to Unix epoch timestamp.
        /// </summary>
        /// <param name="date">The date instance to convert.</param>
        /// <returns>A long integer representing the respective Unix timestamp.</returns>
        public static long ToUnixTimestamp(this DateTime date)
        {
            return (long) Math.Round(
                (date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds
            );
        }
    }
}
