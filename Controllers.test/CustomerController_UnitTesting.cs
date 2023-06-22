using AutoFixture;
using AutoMapper;
using FluentAssertions;
using FoodOrderApi.Controllers;
using FoodOrderApi.DataProvider;
using FoodOrderApi.Mappings;
using FoodOrderApi.Model.Domain;
using FoodOrderApi.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Controllers.test
{
    public class CustomerController_UnitTesting
    {
        private readonly IFixture _fixture;
        private readonly Mock<IDataProvider> _serviceMock;
        private readonly CustomerController _sut;
        private readonly IMapper mapper;
        private readonly ILogger<CustomerController> logger;

        public CustomerController_UnitTesting()
        {
            _fixture = new Fixture();
            _serviceMock = _fixture.Freeze<Mock<IDataProvider>>();
            mapper = _fixture.Freeze<Mock<IMapper>>().Object;
            logger = Mock.Of<ILogger<CustomerController>>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });
            IMapper _mapper = mappingConfig.CreateMapper();
            mapper = _mapper;
            _sut = new CustomerController(_serviceMock.Object, mapper, logger);
        }
        [Fact]
        public async Task GetOrderByName_WithValidCustomerName_ReturnsOkResult()
        {
            //Arrange
            var mock = _fixture.Create<Task<IEnumerable<Order>>>();
            _serviceMock.Setup(x => x.GetOrderByName("string"))
                .Returns(mock);

            //Act
            OkObjectResult results = (OkObjectResult)await _sut.GetOrders("string");

            //Assert      
            results.Value.Equals(mock);
            results.Should().NotBeNull();
            results.Value.Should().BeAssignableTo<IEnumerable<OrderDTO>>();
            results.Should().BeAssignableTo<OkObjectResult>();
        }

        [Fact]
        public async Task GetOrderByName_WithInvalidCustomerName_ReturnsNotFoundResult()
        {
            //Arrange
            _serviceMock.Setup(x => x.GetOrderByName("string"));

            //Act
            var results = await _sut.GetOrders("string");

            //Assert      
            results.Should().NotBeNull();
            results.Should().BeAssignableTo<NotFoundObjectResult>();
        }

    }
}