using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurants.Users.Api.Models.EntityModels
{
    public class UserFavouriteModel
    {
        [Key]
        public string Id { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantContact { get; set; }
        public string RestaurantImgUrl { get; set; }
        public string RestaurantThumbnail { get; set; }
        public string MenuUrl { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AppUserModel User { get; set; }
    }
}
