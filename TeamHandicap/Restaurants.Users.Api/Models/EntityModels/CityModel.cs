using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurants.Users.Api.Models.EntityModels
{
    public class CityModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ShouldExperimentWith { get; set; }
        public int HasGoOutTab { get; set; }
        public int DiscoveryEnabled { get; set; }
        public int HasNewAdFormat { get; set; }
        public int IsState { get; set; }
        
        public int? StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public StateModel State { get; set; }

        public int? CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public CountryModel Country { get; set; }
    }
}
