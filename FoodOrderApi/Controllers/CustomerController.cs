using AutoMapper;
using FoodOrderApi.CustomActionFilter;
using FoodOrderApi.DataProvider;
using FoodOrderApi.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FoodOrderApi.Controllers
{
    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        private IDataProvider _dataProvider;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CustomerController(IDataProvider dataProvider, IMapper mapper, ILogger<CustomerController> logger)
        {
            _dataProvider = dataProvider;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpPost("PlaceOrder")]
        [ValidateModel]
        public async Task<ActionResult> PlaceOrder([FromBody] List<GetOrderDTO> newCustomerOrder)
        {
            var OrderDetails = await _dataProvider.PlaceOrder(newCustomerOrder);
            if (OrderDetails == null)
            {
                _logger.LogError("Can't able to add data as they are invalid.");
                return BadRequest();
            }
            _logger.LogInformation("Data added to the Orders Table.");
            return Ok(_mapper.Map<List<OrderDTO>>(OrderDetails));
        }

        [HttpGet("Orders/{customerName}")]
        public async Task<ActionResult> GetOrders([Required] string customerName)
        {
            var getOrders = await _dataProvider.GetOrderByName(customerName);
            if (!getOrders.Any())
            {
                _logger.LogInformation("Orders not found for the particular person.");
                return NotFound("Orders not found.");
            }
            _logger.LogInformation("Data fetched from the Orders Table.");
            return Ok(_mapper.Map<IEnumerable<OrderDTO>>(getOrders));
        }
    }
}