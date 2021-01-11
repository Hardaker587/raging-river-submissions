using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Restaurants.Users.Api.Models.ResponseModels
{
    public class ZomatoSearchResponseModel
    {
        public int Results_found { get; set; }
        public int Results_start { get; set; }
        public int Results_shown { get; set; }
        public IEnumerable<Dictionary<string, ZomatoRestaurantResponseModel>> Restaurants { get; set; }
    }

    public class ZomatoRestaurantResponseModel
    {
        // public object R { get; set; }
        public int Id { get; set; }
        public bool IsFavourite { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ZomatoRestaurantLocationResponseModel Location { get; set; }
        public int Switch_to_order_menu { get; set; }
        public string Cuisines { get; set; }
        public string Timings { get; set; }
        public decimal Average_cost_for_two { get; set; }
        public float Price_range { get; set; }
        public string Currency { get; set; }
        public IEnumerable<string> Highlights { get; set; }
        // public IEnumerable<object> Offers { get; set; }
        public int Opentable_support {get;set;}
        public int Is_zomato_book_res { get; set; }
        public string Mezzo_provider { get; set; }
        public int Is_book_form_web_view { get; set; }
        public string Book_form_web_view_url { get; set; }
        public string Book_again_url { get; set; }
        public string Thumb { get; set; }
        public ZomatoRestaurantRatingResponseModel User_rating { get; set; }
        public int All_reviews_count { get; set; }
        public string Photos_url { get; set; }
        public int Photo_count { get; set; }
        public string Menu_url { get; set; }
        public string Featured_image { get; set; }
        public bool Medio_provider { get; set; }
        public int Has_online_delivery { get; set; }
        public int Is_delivering_now { get; set; }
        public string Store_type { get; set; }
        public bool Include_bogo_offers { get; set; }
        public string Deeplink { get; set; }
        public int Is_table_reservation_supported { get; set; }
        public int Has_table_booking { get; set; }
        public string Events_url { get; set; }
        public string Phone_numbers { get; set; }
        // public object All_reviews { get; set; }
        public IEnumerable<string> Establishment { get; set; }
        // public IEnumerable<object> Establishment_types { get; set; }
    }

    public class ZomatoRestaurantLocationResponseModel
    {
        public string Address { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public int City_id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Zipcode { get; set; }
        public int Country_id { get; set; }
        public string Locality_verbose { get; set; }
    }

    public class ZomatoRestaurantRatingResponseModel
    {
        public string Aggregate_rating { get; set; }
        public string Rating_text { get; set; }
        public string Rating_color { get; set; }
        public object Rating_obj { get; set; } // {"title":{"text":"4.8"},"bg_color":{"type":"lime","tint":"800"}}
        public int Votes { get; set; }
    }
}
