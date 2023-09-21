using FoodOrderApi.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodOrderApi.Configurations
{
    public class RestaurantConfigurations : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(x => x.RestaurantLocation).HasColumnName("Address");
            builder.Property(x => x.RestaurantPhoneNumber).HasColumnName("Phone Number");
            builder.Property(x => x.RestaurantName).HasColumnName("Name");
            builder.Property(x => x.RestaurantType).HasColumnName("Type");
        }
    }
}