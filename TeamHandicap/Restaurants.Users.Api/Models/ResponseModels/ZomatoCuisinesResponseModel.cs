using System.Collections.Generic;

namespace Restaurants.Users.Api.Models.ResponseModels
{
    public class ZomatoCuisinesResponseModel
    {
        public IEnumerable<Dictionary<string, ZomatoCuisineResponseModel>> Cuisines { get; set; }
    }

    public class ZomatoCuisineResponseModel
    {
        public int Cuisine_id { get; set; }
        public string Cuisine_name { get; set; }
    }
}
