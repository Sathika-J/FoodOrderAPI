using System.ComponentModel.DataAnnotations;

namespace FoodOrderApi.Model.Domain
{
    public class Restaurant
    {
        [Key]
        public Guid RestaurantID { get; set; }

        public string RestaurantName { get; set; }
        public string RestaurantType { get; set; }
        public int RestaurantPhoneNumber { get; set; }
        public string RestaurantLocation { get; set; }
    }
}