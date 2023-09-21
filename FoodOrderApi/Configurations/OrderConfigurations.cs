using FoodOrderApi.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodOrderApi.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.IsDelivered)
                .HasColumnName("Status")
                .HasConversion(v => BooleanConvertor.ConvertToString(v),
                               v => BooleanConvertor.ConvertToBool(v));
            builder.Property(x => x.CustomerName)
                .HasMaxLength(50)
                .HasColumnName("Customer Name");
        }
    }
}