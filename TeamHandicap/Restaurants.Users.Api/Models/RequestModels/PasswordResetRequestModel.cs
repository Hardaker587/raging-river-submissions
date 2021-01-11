
namespace Restaurants.Users.Api.Models.RequestModels
{
    public class PasswordResetRequestModel
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
