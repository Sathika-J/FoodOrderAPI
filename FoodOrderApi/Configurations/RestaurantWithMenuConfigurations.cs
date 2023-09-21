using FoodOrderApi.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStack.Text;

namespace FoodOrderApi.Configurations
{
    public class RestaurantWithMenuConfigurations : IEntityTypeConfiguration<RestaurantWithMenu>
    {
        public void Configure(EntityTypeBuilder<RestaurantWithMenu> builder)
        {
            builder
            .Property(x => x.Menus)
                .HasConversion(v => CsvSerializer.SerializeToCsv(v),
                               v => CsvSerializer.DeserializeFromString<List<string>>(v),
                               new ValueComparer<IList<string>>(
                                                        (c1, c2) => c1.SequenceEqual(c2),
                                                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                                                        c => (IList<string>)c.ToList()));
            builder.Property(x => x.RestaurantLocation).HasColumnName("Address");
            builder.Property(x => x.RestaurantPhoneNumber).HasColumnName("Phone Number");
            //builder.Property(x => x.RestaurantOffer).HasColumnName("Discount");
            builder.Property(x => x.RestaurantName).HasColumnName("Name");
            builder.Property(x => x.RestaurantType).HasColumnName("Type");
        }
    }
}