using FoodOrderApi.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodOrderApi.Configurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(x => x.ProductID).HasColumnName("Item ID");
            builder.Property(x => x.RestaurantID).HasColumnName("Restaurant ID");
            builder.Property(x => x.ProductName).HasColumnName("Item Name");
            builder.Property(x => x.ProductPrice).HasColumnName("Item Price (₹)").HasPrecision(2, 3);
            builder.Property(x => x.ProductOffer).HasColumnName("Item Discount (%)");
        }
    }
}