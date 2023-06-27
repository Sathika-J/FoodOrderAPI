using System.ComponentModel.DataAnnotations;

namespace FoodOrderApi.Model.DTO
{
    public class GetOrderDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be a minimum of 3 characters")]
        [MaxLength(200, ErrorMessage = "Name has to be a maximum of 3 characters")]
        public string CustomerName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Restaurant Name has to be a maximum of 3 characters")]
        public string RestaurantName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Menu item has to be a maximum of 3 characters")]
        public string ProductName { get; set; }
    }
}