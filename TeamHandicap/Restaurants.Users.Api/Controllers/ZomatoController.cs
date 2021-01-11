using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Restaurants.Users.Api.Helpers;
using Restaurants.Users.Api.Models.EntityModels;
using Restaurants.Users.Api.Models.ResponseModels;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Restaurants.Users.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ZomatoController : ControllerBase
    {
        private readonly IConfiguration _appConfig;
        private readonly AppDbContext _appDbContext;

        public ZomatoController(IConfiguration appConfig, AppDbContext appDbContext)
        {
            _appConfig = appConfig;
            _appDbContext = appDbContext;
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> Categories()
        {
            var response = await _getIseClient().GetAsync("categories");
            response.EnsureSuccessStatusCode();

            var jsonContent = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<ZomatoCategoriesResponseModel>(jsonContent);

            return Ok(categories.Categories.Select(c => c.Values.First()));
        }

        [HttpGet("Cuisines")]
        public async Task<IActionResult> Cuisines(int cityId, decimal? lat, decimal? lon)
        {
            if (cityId <= 0 && (lat == null || lon == null))
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "Either cityId or lat and lon should be provided.", ModelState));
            }

            var queryStr = cityId > 0 ? $"city_id={cityId}" : $"lat={lat}&lon={lon}";
            var response = await _getIseClient().GetAsync($"cuisines?{queryStr}");
            var jsonContent1 = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            var jsonContent = await response.Content.ReadAsStringAsync();
            var cuisines = JsonConvert.DeserializeObject<ZomatoCuisinesResponseModel>(jsonContent);

            return Ok(cuisines.Cuisines.Select(c => new
            {
                Id = c.Values.First().Cuisine_id,
                Name = c.Values.First().Cuisine_name
            }));
        }

        [HttpGet("Restaurants")]
        public async Task<IActionResult> Restaurants(int start, int cityId, decimal? lat, decimal? lon, int categoryId, int cuisineId, string search, int pageSize = 20, int radius = 5000)
        {
            if (cityId <= 0 && (lat == null || lon == null))
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "Either cityId or lat and lon should be provided.", ModelState));
            }

            var queryString = $"?start={start}&count={pageSize}";
            if (cityId > 0)
            {
                queryString += $"&entity_type=city&entity_id={cityId}";
            } 
            else
            {
                queryString += $"&lat={lat}&lon={lon}&radius={radius}";
            }

            if (categoryId > 0)
            {
                queryString += $"&category={categoryId}";
            }

            if (cuisineId > 0)
            {
                queryString += $"&cuisines={cuisineId}";
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                queryString += $"&q={search}";
            }

            var response = await _getIseClient().GetAsync($"search{queryString}");
            response.EnsureSuccessStatusCode();

            var jsonContent = await response.Content.ReadAsStringAsync();
            var restaurants = JsonConvert.DeserializeObject<ZomatoSearchResponseModel>(jsonContent);
            var results = restaurants.Restaurants.Select(r => r.Values.First());


            var user = await AuthHelper.GetCurrentUserAsync(_appDbContext, HttpContext);
            foreach (var restaurant in results)
            {
                restaurant.IsFavourite = user?.Favourites?.Any(f => f.RestaurantId == restaurant.Id) ?? false;
            }

            return Ok(new
            {
                restaurants.Results_found,
                restaurants.Results_shown,
                restaurants.Results_start,
                Results = results
            });
        }

        [HttpGet("Restaurant/{restaurantId}")]
        public async Task<IActionResult> GetRestaurant(int restaurantId)
        {
            var response = await _getIseClient().GetAsync($"restaurant?res_id={restaurantId}");
            response.EnsureSuccessStatusCode();

            var jsonContent = await response.Content.ReadAsStringAsync();
            var restaurant = JsonConvert.DeserializeObject<ZomatoRestaurantResponseModel>(jsonContent);

            var user = await AuthHelper.GetCurrentUserAsync(_appDbContext, HttpContext);
            restaurant.IsFavourite = user?.Favourites?.Any(f => f.RestaurantId == restaurant.Id) ?? false;

            return Ok(restaurant);
        }

        [HttpGet("Countries")]
        public async Task<IActionResult> Countries()
        {
            var result = await _appDbContext.Countries.Select(c => new
            {
                c.Id,
                c.Name,
                ImgUrl = c.FlagUrl,
                HasStates = _appDbContext.States.Any(s => s.CountryId == c.Id)
            }).OrderBy(c => c.Name).ToListAsync();

            return Ok(result);
        }

        [HttpGet("States")]
        public async Task<IActionResult> States(int? countryId)
        {
            var result = await _appDbContext.States.Where(s => countryId == null || countryId == 0 || s.CountryId == countryId).Select(s => new
            {
                s.Id,
                s.Name,
                s.Code,
                s.CountryId
            }).OrderBy(s => s.Name).ToListAsync();

            return Ok(result);
        }

        [HttpGet("Cities")]
        public async Task<IActionResult> Cities(int? stateId, int? countryId)
        {
            IQueryable<CityModel> query;

            if (stateId > 0)
            {
                query = _appDbContext.Cities.Where(c => c.StateId == stateId);
            }
            else
            {
                query = _appDbContext.Cities.Where(c => countryId == null || countryId == 0 || c.CountryId == countryId); ;
            }

            var result = await query.Select(c => new
            {
                c.Id,
                c.Name,
                c.HasGoOutTab,
                c.HasNewAdFormat,
                c.IsState,
                c.ShouldExperimentWith,
                c.StateId,
                c.CountryId
            }).OrderBy(c => c.Name).ToListAsync();

            return Ok(result);
        }

        [HttpGet("City/{cityId}")]
        public async Task<IActionResult> GetCity(int cityId)
        {
            var city = await _appDbContext.Cities.Include(c => c.State).Include(c => c.Country).SingleOrDefaultAsync(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                city.Id,
                city.Name,
                State = city.State?.Name,
                Country = city.Country?.Name
            });
        }

        [Authorize, HttpGet("Favourites")]
        public async Task<IActionResult> GetFavourites()
        {
            var user = await AuthHelper.GetCurrentUserAsync(_appDbContext, HttpContext);
            return Ok(user?.Favourites.Select(f => new
            {
                f.Id,
                f.MenuUrl,
                f.RestaurantAddress,
                f.RestaurantContact,
                f.RestaurantId,
                f.RestaurantImgUrl,
                f.RestaurantThumbnail,
                f.RestaurantName
            }));
        }

        [Authorize, HttpPost("Favourite")]
        public async Task<IActionResult> MarkAsFavourite([FromBody]ZomatoRestaurantResponseModel model)
        {
            var user = await AuthHelper.GetCurrentUserAsync(_appDbContext, HttpContext);

            if (user.Favourites.Any(f => f.RestaurantId == model.Id))
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "Already a favourite.", ModelState));
            }

            _appDbContext.UserFavourites.Add(new UserFavouriteModel
            {
                Id = Guid.NewGuid().ToString(),
                RestaurantId = model.Id,
                RestaurantAddress = model.Location.Address,
                RestaurantImgUrl = model.Featured_image,
                RestaurantThumbnail = model.Thumb,
                RestaurantName = model.Name,
                MenuUrl = model.Menu_url,
                RestaurantContact = model.Phone_numbers,
                UserId = user.Id
            });
            await _appDbContext.SaveChangesAsync();

            return Ok();
        }

        [Authorize, HttpDelete("Favourite/{restaurantId}")]
        public async Task<IActionResult> DeleteFavourite(int restaurantId)
        {
            var user = await AuthHelper.GetCurrentUserAsync(_appDbContext, HttpContext);
            var restaurant = user.Favourites.SingleOrDefault(f => f.RestaurantId == restaurantId);
            
            if (restaurant != null)
            {
                _appDbContext.UserFavourites.Remove(restaurant);
                await _appDbContext.SaveChangesAsync();
            }

            return Ok();
        }

        private HttpClient _getIseClient()
        {
            var ZomatoApiBaseUrl = _appConfig["ZomatoApi:BaseUrl"];
            var ZomatoApiKey = _appConfig["ZomatoApi:Key"];

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ZomatoApiBaseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("user-key", ZomatoApiKey);
            httpClient.DefaultRequestHeaders.ExpectContinue = false;
            
            return httpClient;
        }
    }
}
