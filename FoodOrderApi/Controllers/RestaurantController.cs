using AutoMapper;
using FoodOrderApi.DataProvider;
using FoodOrderApi.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FoodOrderApi.Controllers
{
    [Route("Restaurant")]
    public class RestaurantController : ControllerBase
    {
        private IDataProvider _dataProvider;
        private int _maxPageSize = 10;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public RestaurantController(IDataProvider dataProvider, IMapper mapper, ILogger<RestaurantController> logger)
        {
            _dataProvider = dataProvider;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetRestaurant([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 3)
        {
            if (pageSize > _maxPageSize)
            {
                pageSize = _maxPageSize;
            }
            // Get the restaurants
            var (allRestaurants, metadata) = await _dataProvider.GetRestaurantPaged(pageNumber, pageSize);
            var restaurantMapper = _mapper.Map<List<DisplayRestaurantDTO>>(allRestaurants.ToList());
            if (allRestaurants.Count() != 0)
            {
                _logger.LogInformation("Data fetched from the restaurant table.");
                var serializerOutput = System.Text.Json.JsonSerializer.Serialize(metadata);
                Response.Headers.Add("X-Pagination", serializerOutput);
                return Ok(restaurantMapper);
            }
            else
            {
                Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(metadata));
                return NotFound("Restaurants not found!");
            }
        }

        [HttpGet("RestaurantByName")]
        public async Task<ActionResult> GetRestaurantByName([FromQuery] string? filterString)
        {
            var restaurants = (await _dataProvider.FilterRestaurant(filterString));
            var restaurantMapper = _mapper.Map<List<DisplayRestaurantDTO>>(restaurants.ToList());
            return Ok(restaurantMapper);
        }

        [HttpGet("Search")]
        public async Task<ActionResult> SearchRestaurantandMenu([FromQuery][Required] string searchString)
        {
            if (searchString.Trim().Length != 0)
            {
                var searched = (await _dataProvider.SearchMenuAndRestaurant(searchString.Trim()));
                var restaurantDTOMapper = _mapper.Map<List<RestaurantDTO>>(searched.restaurant);
                var menuDTOMapper = _mapper.Map<List<DisplayMenuDTO>>(searched.menu);
                RestaurantsandMenusDTO restaurantsandMenusDTOs = new RestaurantsandMenusDTO();
                restaurantsandMenusDTOs.menu = menuDTOMapper;
                restaurantsandMenusDTOs.restaurant = restaurantDTOMapper;
                if (restaurantsandMenusDTOs.menu.Count() > 0 && restaurantsandMenusDTOs.restaurant.Count() > 0)
                {
                    return Ok(restaurantsandMenusDTOs);
                }
                else if (searched.menu.Count() > 0)
                {
                    return Ok(restaurantsandMenusDTOs.menu);
                }
                else if (restaurantsandMenusDTOs.restaurant.Count() > 0)
                {
                    return Ok(restaurantsandMenusDTOs.restaurant);
                }
            }
            return NotFound();
        }

        [HttpGet("Menu")]
        public async Task<ActionResult> GetMenu()
        {
            var menus = await (_dataProvider.GetMenus());
            var menusMapper = _mapper.Map<List<DisplayMenuDTO>>(menus.ToList());
            _logger.LogInformation("Data fetched from the Menu table.");
            return Ok(menus);
        }

        [HttpGet("RestaurantwithMenus")]
        public async Task<ActionResult> GetRestaurantWithMenu([Required] string RestrauntName)
        {
            var restaurantsWithMenu = await _dataProvider.GetRestaurantWithMenu(RestrauntName);
            if (restaurantsWithMenu == null)
            {
                _logger.LogError("Restaurant not found in the database.");
                return NotFound("Restaurant not found.");
            }
            var restaurantMapper = _mapper.Map<List<string>>(restaurantsWithMenu.ToList());
            _logger.LogInformation("Data fetched from the Restaurant with Menu table.");
            return Ok(restaurantMapper);
        }
    }
}