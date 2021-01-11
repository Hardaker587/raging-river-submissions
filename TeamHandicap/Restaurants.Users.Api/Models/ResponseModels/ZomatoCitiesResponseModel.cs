using System.Collections.Generic;

namespace Restaurants.Users.Api.Models.ResponseModels
{
    public class ZomatoCitiesResponseModel
    {
        public IEnumerable<ZomatoCityResponseModel> Location_suggestions { get; set; }
        public string Status { get; set; }
        public int Has_more { get; set; }
        public int Has_total { get; set; }
        public bool User_has_addresses { get; set; }
    }

    public class ZomatoCityResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Country_id { get; set; }
        public string Country_name { get; set; }
        public string Country_flag_url { get; set; }
        public int Should_experiment_with { get; set; }
        public int Has_go_out_tab { get; set; }
        public int Discovery_enabled { get; set; }
        public int Has_new_ad_format { get; set; }
        public int Is_state { get; set; }
        public int? State_id { get; set; }
        public string State_name { get; set; }
        public string State_code { get; set; }
    }
}
