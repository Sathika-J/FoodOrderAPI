namespace FoodOrderApi.Model.DTO
{
    public class OrderDTO
    {
        public Guid OrderID { get; set; }
        public bool IsDelivered { get; set; }

        //Navigation
        public RestaurantDTO Restaurant { get; set; }

        public MenuDTO Menu { get; set; }
    }
}