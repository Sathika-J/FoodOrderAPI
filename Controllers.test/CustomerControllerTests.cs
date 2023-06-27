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
    public class CustomerControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IDataProvider> _serviceMock;
        private readonly CustomerController _customerController;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;

        public CustomerControllerTests()
        {
            _fixture = new Fixture();
            _serviceMock = _fixture.Freeze<Mock<IDataProvider>>();
            this._mapper = _fixture.Freeze<Mock<IMapper>>().Object;
            _logger = Mock.Of<ILogger<CustomerController>>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });
            IMapper _mapper = mappingConfig.CreateMapper();
            this._mapper = _mapper;
            _customerController = new CustomerController(_serviceMock.Object, this._mapper, _logger);
        }

        [Fact]
        public async Task GetOrderByName_WithValidCustomerName_ReturnsOkResult()
        {
            var mock = _fixture.Create<Task<IEnumerable<Order>>>();
            _serviceMock.Setup(x => x.GetOrderByName("string"))
                .Returns(mock);

            OkObjectResult results = (OkObjectResult)await _customerController.GetOrders("string");

            results.Value.Equals(mock);
            results.Should().NotBeNull();
            results.Value.Should().BeAssignableTo<IEnumerable<OrderDTO>>();
            results.Should().BeAssignableTo<OkObjectResult>();
        }

        [Fact]
        public async Task GetOrderByName_WithInvalidCustomerName_ReturnsNotFoundResult()
        {
            _serviceMock.Setup(x => x.GetOrderByName("string"));

            var results = await _customerController.GetOrders("string");

            results.Should().NotBeNull();
            results.Should().BeAssignableTo<NotFoundObjectResult>();
        }

        [Fact]
        public async Task PlaceOrder_WithValidData_ReturnsOkResult()
        {
            var mock = _fixture.Create<List<GetOrderDTO>>();
            var mock1 = _fixture.Create<Task<List<Order>>>();
            _serviceMock.Setup(x => x.PlaceOrder(mock))
                .Returns(mock1);

            OkObjectResult results = (OkObjectResult)await _customerController.PlaceOrder(mock);

            results.Value.Equals(mock);
            results.Should().NotBeNull();
            results.Value.Should().BeAssignableTo<IEnumerable<OrderDTO>>();
            results.Should().BeAssignableTo<OkObjectResult>();
        }

        [Fact]
        public async Task PlaceOrder_WithInvalidData_ReturnsBadRequest()
        {
            var mock = _fixture.Create<List<GetOrderDTO>>();
            _serviceMock.Setup(x => x.PlaceOrder(mock));

            var results = _customerController.PlaceOrder(mock);

            results.Should().NotBeNull();
            results.Result.Should().BeAssignableTo<BadRequestResult>();
        }
    }
}