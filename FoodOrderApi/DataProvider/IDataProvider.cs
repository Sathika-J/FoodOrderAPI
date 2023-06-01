﻿using FoodOrderApi.Model.Domain;
using FoodOrderApi.Model.DTO;

namespace FoodOrderApi.DataProvider
{
    public interface IDataProvider
    {
        Task<IEnumerable<Menu>> GetMenus();

        Task<IEnumerable<Restaurant>> GetRestaurant();

        Task<IList<string>?> GetRestaurantWithMenu(string restaurantName);

        Task<IEnumerable<Order>> GetOrderByName(string customerName);

        Task<List<Order>?> PlaceOrder(List<GetOrderDTO> newCustomerOrder);

        Task<bool> OrderDelivered(Guid CustomerOrderId);
    }
}