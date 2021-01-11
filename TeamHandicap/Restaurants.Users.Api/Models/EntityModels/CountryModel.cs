using System.ComponentModel.DataAnnotations;

namespace Restaurants.Users.Api.Models.EntityModels
{
    public class CountryModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FlagUrl { get; set; }
    }
}
