using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurants.Users.Api.Models.EntityModels
{
    public class StateModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int? CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public CountryModel Country { get; set; }
    }
}
