using FoodOrderApi.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FoodOrderApi.Repository
{
    public class FakeFoodApiDbContext : DbContext, IDbProvider
    {
        public FakeFoodApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<RestaurantWithMenu> RestaurantWithMenus { get; set; }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}