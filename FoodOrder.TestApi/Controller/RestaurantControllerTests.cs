using AutoMapper;
using FluentAssertions;
using FoodOrderApi.Controllers;
using FoodOrderApi.DataProvider;
using FoodOrderApi.Mappings;
using FoodOrderApi.Model.DTO;
using FoodOrderApi.TestApi.Mockdata;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;

namespace FoodOrderApi.TestApi.Controller
{
    public class RestaurantControllerTests
    {
        private Mock<IDataProvider> _restaurantService;
        private IMapper _mapperMock;
        private Mock<ILogger<RestaurantController>> _loggerMock;

        public RestaurantControllerTests()
        {
            _restaurantService = new Mock<IDataProvider>();
            _loggerMock = new Mock<ILogger<RestaurantController>>();
            if (_mapperMock == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapperMock = mapper;
            }
        }

        [Theory]
        [InlineData(1, 10)]
        [InlineData(3, 2)]
        public async Task GetAllRestaurant_PagationWithValidIndex_ShouldReturn200Status(int pageNumber, int pageSize)
        {
            _restaurantService.Setup(_ => _.GetRestaurantPaged(pageNumber, pageSize)).ReturnsAsync(RestaurantMockData.GetRestaurantPaged(pageNumber, pageSize));
            var restaurantController = new RestaurantController(_restaurantService.Object, _mapperMock, _loggerMock.Object);
            restaurantController.ControllerContext = new ControllerContext();
            restaurantController.ControllerContext.HttpContext = new DefaultHttpContext();

            var result = await restaurantController.GetRestaurant(pageNumber, pageSize);
            var model = (result as OkObjectResult).Value as List<DisplayRestaurantDTO>;

            model.Should().HaveCount(RestaurantMockData.GetRestaurantPaged(pageNumber, pageSize).Item1.Count());
            result.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(11, 10)]
        [InlineData(10, 7)]
        public async Task GetAllRestaurant_PagationWithInValidIndex_ShouldReturn200Status(int pageNumber, int pageSize)
        {
            _restaurantService.Setup(_ => _.GetRestaurantPaged(pageNumber, pageSize)).ReturnsAsync(RestaurantMockData.GetRestaurantPaged(pageNumber, pageSize));
            var restaurantController = new RestaurantController(_restaurantService.Object, _mapperMock, _loggerMock.Object);
            restaurantController.ControllerContext = new ControllerContext();
            restaurantController.ControllerContext.HttpContext = new DefaultHttpContext();

            var result = await restaurantController.GetRestaurant(pageNumber, pageSize);

            result.Should().BeOfType<NotFoundObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData("Annapoorna")]
        [InlineData("Bhavan")]
        [InlineData("")]
        public async Task GetRestaurantByName_FilterRestaurantNamePassed_ShouldReturn200Status(string filterString)
        {
            _restaurantService.Setup(_ => _.FilterRestaurant(filterString)).ReturnsAsync(RestaurantMockData.GetFilteredRestaurants(filterString));
            var restaurantController = new RestaurantController(_restaurantService.Object, _mapperMock, _loggerMock.Object);

            var result = await restaurantController.GetRestaurantByName(filterString);

            result.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Annapoorna")]
        [InlineData("Bhavan")]
        public async Task SearchRestaurantandMenu_ValidSearchString_ShouldReturn200Status(string searchString)
        {
            _restaurantService.Setup(_ => _.SearchMenuAndRestaurant(searchString)).ReturnsAsync(RestaurantMockData.GetSearchRestaurantAndMenu(searchString));
            var restaurantController = new RestaurantController(_restaurantService.Object, _mapperMock, _loggerMock.Object);

            var result = await restaurantController.SearchRestaurantandMenu(searchString);

            result.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("")]
        public async Task SearchRestaurantandMenu_InvalidSearchString_ShouldReturn404Status(string searchString)
        {
            _restaurantService.Setup(_ => _.SearchMenuAndRestaurant(searchString)).ReturnsAsync(RestaurantMockData.GetSearchRestaurantAndMenu(searchString));
            var restaurantController = new RestaurantController(_restaurantService.Object, _mapperMock, _loggerMock.Object);

            var result = await restaurantController.SearchRestaurantandMenu(searchString);

            result.Should().BeOfType<NotFoundResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetAllMenu_FetchAllMenus_ShouldReturn200Status()
        {
            _restaurantService.Setup(_ => _.GetMenus()).ReturnsAsync(RestaurantMockData.GetAllMenus());
            var restaurantController = new RestaurantController(_restaurantService.Object, _mapperMock, _loggerMock.Object);

            var result = await restaurantController.GetMenu();

            result.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}