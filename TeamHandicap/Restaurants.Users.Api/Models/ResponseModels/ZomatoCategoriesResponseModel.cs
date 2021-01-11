using System.Collections.Generic;

namespace Restaurants.Users.Api.Models.ResponseModels
{
    public class ZomatoCategoriesResponseModel
    {
        public IEnumerable<Dictionary<string, ZomatoCategoryResponseModel>> Categories { get; set; }
    }

    public class ZomatoCategoryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
