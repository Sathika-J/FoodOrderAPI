using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderApi.Model.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid RestaurantID { get; set; }
        public Guid ProductID { get; set; }
        public string CustomerName { get; set; }
        public bool IsDelivered { get; set; }
        public Restaurant Restaurant { get; set; }

        [ForeignKey("ProductID")]
        public Menu Menu { get; set; }
    }
}