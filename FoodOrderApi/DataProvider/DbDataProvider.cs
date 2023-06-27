using AutoMapper;
using FoodOrderApi.Controllers;
using FoodOrderApi.Model.Domain;
using FoodOrderApi.Model.DTO;
using FoodOrderApi.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderApi.DataProvider
{
    public class DbDataProvider : Controller, IDataProvider
    {
        private readonly IDbProvider _foodApiDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RestaurantController> _logger;

        public DbDataProvider(IDbProvider foodApiDbContext, IMapper mapper, ILogger<RestaurantController> logger)
        {
            this._foodApiDbContext = foodApiDbContext;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<IEnumerable<Menu>> GetMenus()
        {
            return await _foodApiDbContext.Menus.Include("Restaurant").ToListAsync();
        }

        public async Task<IEnumerable<Order>?> GetOrderByName(string customerName)
        {
            return await _foodApiDbContext.Orders.Where(item => item.CustomerName == customerName).Include("Menu").Include("Restaurant").ToListAsync();
        }

        public async Task<RestaurantsandMenus> SearchMenuAndRestaurant(string searchString)
        {
            var restaurants = _foodApiDbContext.Restaurants.AsQueryable();
            var menus = _foodApiDbContext.Menus.AsQueryable();
            restaurants = restaurants.Where(x => x.RestaurantName.ToLower().Contains(searchString.ToLower()));
            menus = menus.Where(x => x.ProductName.ToLower().Contains(searchString.ToLower())).Include("Restaurant");
            RestaurantsandMenus restaurantsandMenus = new RestaurantsandMenus();
            restaurantsandMenus.menu = await menus.ToListAsync();
            restaurantsandMenus.restaurant = await restaurants.ToListAsync();
            return restaurantsandMenus;
        }

        public async Task<IEnumerable<Restaurant>> FilterRestaurant(string? filterString = null)
        {
            var restaurants = _foodApiDbContext.Restaurants.AsQueryable();
            if (filterString != null)
            {
                restaurants = restaurants.Where(x => x.RestaurantName.ToLower().Contains(filterString.ToLower()));
                _logger.LogInformation("Data fetched from the restaurant table.");
            }
            return await restaurants.ToListAsync();
        }

        public async Task<(IEnumerable<Restaurant>, PaginationMetadata)> GetRestaurantPaged(int pageNumber, int pageSize)
        {
            var productsCount = await _foodApiDbContext.Restaurants.CountAsync();
            var paginationMetadata = new PaginationMetadata(productsCount, pageSize, pageNumber);

            var paginatedProducts = await _foodApiDbContext.Restaurants
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
            return (paginatedProducts, paginationMetadata);
        }

        public async Task<IList<string>?> GetRestaurantWithMenu(string restaurantName)
        {
            var getParticularRestaurant = await (_foodApiDbContext.RestaurantWithMenus.FirstOrDefaultAsync(item => item.RestaurantName.ToLower() == restaurantName.ToLower()));
            if (getParticularRestaurant != null)
            {
                return getParticularRestaurant.Menus;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Order>?> PlaceOrder(List<GetOrderDTO> newCustomerOrder)
        {
            var orderList = new List<Order>();
            foreach (var customerOrder in newCustomerOrder)
            {
                var restaurants = (await GetRestaurant()).ToList().Where(item => item.RestaurantName.ToLower() == customerOrder.RestaurantName.ToLower()).ToList();
                if (restaurants.Count() > 0)
                {
                    var products = (await GetMenus()).Where(item => (item.ProductName.ToLower() == customerOrder.ProductName.ToLower()) && (item.RestaurantID == restaurants[0].RestaurantID)).ToList();
                    if (products.Count() > 0)
                    {
                        var newOrder = _mapper.Map<Order>(customerOrder);
                        newOrder.RestaurantID = products[0].RestaurantID;
                        newOrder.ProductID = products[0].ProductID;
                        newOrder.IsDelivered = false;
                        await _foodApiDbContext.Orders.AddAsync(newOrder);
                        await _foodApiDbContext.SaveChangesAsync();
                        orderList.Add(newOrder);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            return orderList;
        }

        public async Task<bool> OrderDelivered(Guid CustomerOrderId)
        {
            var CustomerOrder = await _foodApiDbContext.Orders.FirstOrDefaultAsync(item => item.Id == CustomerOrderId);
            if (CustomerOrder == null)
            {
                return false;
            }
            CustomerOrder.IsDelivered = true;
            await _foodApiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurant()
        {
            return await _foodApiDbContext.Restaurants.ToListAsync();
        }

        public async Task<bool> Discount(Guid restaurantID, Guid productID, double discount)
        {
            var menu = await _foodApiDbContext.Menus.FirstOrDefaultAsync(x => x.RestaurantID == restaurantID && x.ProductID == productID);
            if (menu == null)
            {
                return false;
            }
            menu.ProductOffer = discount;
            await _foodApiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMenu(Guid MenuID)
        {
            var Menu = await _foodApiDbContext.Menus.FirstOrDefaultAsync(x => x.ProductID == MenuID);
            if (Menu == null)
            {
                return false;
            }
            _foodApiDbContext.Menus.Remove(Menu);
            await _foodApiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Menu> PatchMenuItems(Guid RestaurantID, JsonPatchDocument<Menu> jsonPatchDocument)
        {
            var restaurantMenus = await _foodApiDbContext.Menus.FirstOrDefaultAsync(x => x.RestaurantID == RestaurantID);

            if (restaurantMenus != null)
            {
                var newMenu = new Menu();
                jsonPatchDocument.ApplyTo(newMenu, ModelState);
                newMenu.ProductID = Guid.NewGuid();
                newMenu.RestaurantID = RestaurantID;
                _foodApiDbContext.Menus.Update(newMenu);
                await _foodApiDbContext.SaveChangesAsync();
                if (!ModelState.IsValid)
                {
                    return null;
                }
                return newMenu;
            }
            return null;
        }
    }
}