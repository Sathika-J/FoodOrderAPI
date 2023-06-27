using AutoMapper;
using FluentAssertions;
using FoodOrderApi.Controllers;
using FoodOrderApi.DataProvider;
using FoodOrderApi.Mappings;
using FoodOrderApi.Repository;
using FoodOrderApi.TestApi.Mockdata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace FoodOrderApi.TestApi.Services
{
    public class RestaurantServiceTests : IDisposable
    {
        protected readonly FakeFoodApiDbContext _context;
        private IMapper _mapperMock;
        private Mock<ILogger<RestaurantController>> _loggerMock;

        public RestaurantServiceTests()
        {
            var options = new DbContextOptionsBuilder<FakeFoodApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new FakeFoodApiDbContext(options);
            if (_mapperMock == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapperMock = mapper;
            }
            _loggerMock = new Mock<ILogger<RestaurantController>>();

            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllRestaurant_ReturnRestaurantCollection()
        {
            _context.Restaurants.AddRange(RestaurantMockData.GetAllRestaurants());
            await _context.SaveChangesAsync();

            var dbDataProvider = new DbDataProvider(_context, _mapperMock, _loggerMock.Object);

            var result = await dbDataProvider.GetRestaurant();

            result.Should().HaveCount(RestaurantMockData.GetAllRestaurants().Count);
        }

        [Fact]
        public async Task GetAllMenus_ReturnMenuCollection()
        {
            _context.Menus.AddRange(RestaurantMockData.GetAllMenus());
            await _context.SaveChangesAsync();

            var dbDataProvider = new DbDataProvider(_context, _mapperMock, _loggerMock.Object);

            var result = await dbDataProvider.GetMenus();

            result.Should().HaveCount(RestaurantMockData.GetAllMenus().Count);
        }

        [Theory]
        [InlineData("Annapoorna")]
        [InlineData("Aravind Hotel")]
        [InlineData("")]
        public async Task GetFilterRestaurantName_ValidFilterString_ReturnRestaurantsCollection(string stringToBeFiltered)
        {
            _context.Restaurants.AddRange(RestaurantMockData.GetFilteredRestaurants(stringToBeFiltered));
            await _context.SaveChangesAsync();

            var dbDataProvider = new DbDataProvider(_context, _mapperMock, _loggerMock.Object);

            var result = await dbDataProvider.FilterRestaurant(stringToBeFiltered);

            result.Should().HaveCount(RestaurantMockData.GetFilteredRestaurants(stringToBeFiltered).Count);
        }

        [Theory]
        [InlineData("Annapoorna")]
        [InlineData("Aravind Hotel")]
        public async Task GetSearchRestaurantAndMenu_ValidSearchString_ReturnRestaurantAndMenuCollection(string stringToBeFiltered)
        {
            _context.Restaurants.AddRange(RestaurantMockData.GetFilteredRestaurants(stringToBeFiltered));
            await _context.SaveChangesAsync();

            var dbDataProvider = new DbDataProvider(_context, _mapperMock, _loggerMock.Object);

            var result = await dbDataProvider.SearchMenuAndRestaurant(stringToBeFiltered);
            /// Assert
            result.menu.Should().HaveCount(RestaurantMockData.GetSearchRestaurantAndMenu(stringToBeFiltered).menu.Count);
            result.restaurant.Should().HaveCount(RestaurantMockData.GetSearchRestaurantAndMenu(stringToBeFiltered).restaurant.Count);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}