using FoodOrderApi.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderApi.Repository
{
    public interface IDbProvider
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<RestaurantWithMenu> RestaurantWithMenus { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}