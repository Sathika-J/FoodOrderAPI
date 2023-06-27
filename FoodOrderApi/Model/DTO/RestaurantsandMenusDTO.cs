namespace FoodOrderApi.Model.DTO
{
    public class RestaurantsandMenusDTO
    {
        public List<DisplayMenuDTO> menu { get; set; }
        public List<RestaurantDTO> restaurant { get; set; }
    }
}