namespace FoodOrderApi.Model.DTO
{
    public class DisplayMenuDTO
    {
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public double ProductOffer { get; set; }
        public RestaurantDTO Restaurant { get; set; }
    }
}