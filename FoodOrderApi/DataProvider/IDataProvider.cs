using FoodOrderApi.Model.Domain;
using FoodOrderApi.Model.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace FoodOrderApi.DataProvider
{
    public interface IDataProvider
    {
        Task<IEnumerable<Menu>> GetMenus();

        Task<(IEnumerable<Restaurant>, PaginationMetadata)> GetRestaurantPaged(int pageNumber, int pageSize);

        Task<IEnumerable<Restaurant>> GetRestaurant();

        Task<IList<string>?> GetRestaurantWithMenu(string restaurantName);

        Task<IEnumerable<Order>> GetOrderByName(string customerName);

        Task<List<Order>?> PlaceOrder(List<GetOrderDTO> newCustomerOrder);

        Task<bool> OrderDelivered(Guid CustomerOrderId);

        Task<IEnumerable<Restaurant>> FilterRestaurant(string? filterString = null);

        Task<RestaurantsandMenus> SearchMenuAndRestaurant(string searchString);

        Task<bool> DeleteMenu(Guid MenuID);

        Task<bool> Discount(Guid restaurantID, Guid productID, double discount);

        Task<Menu> PatchMenuItems(Guid RestaurantID, JsonPatchDocument<Menu> jsonPatchDocument);
    }
}