using AutoMapper;
using FoodOrderApi.DataProvider;
using FoodOrderApi.Model.Domain;
using FoodOrderApi.Model.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FoodOrderApi.Controllers
{
    [Route("Admin")]
    public class AdminController : ControllerBase
    {
        private IDataProvider _dataProvider;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public IDataProvider Object { get; }

        public AdminController(IDataProvider dataProvider, IMapper mapper, ILogger<AdminController> logger)
        {
            _dataProvider = dataProvider;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpDelete("DeleteMenu/{MenuID:Guid}")]
        public async Task<ActionResult> DeleteMenu([Required] Guid MenuID)
        {
            var IsDeleted = _dataProvider.DeleteMenu(MenuID);
            if (IsDeleted.Result)
            {
                _logger.LogInformation("Menu removed from the hotel");
                return Ok("Menu removed from the hotel");
            }
            else
            {
                _logger.LogInformation("Can't able to found the menu");
                return BadRequest("Can't able to found the menu");
            }
        }

        [HttpPut("OrderDelivered/{orderId:GUID}")]
        public async Task<ActionResult> OrderDelivered([Required] Guid orderId)
        {
            var IsDelivered = _dataProvider.OrderDelivered(orderId);
            if (IsDelivered.Result)
            {
                _logger.LogInformation("Order delivered and changed in the database.");
                return Ok("Success");
            }
            else
            {
                _logger.LogInformation("Order not found.");
                return NotFound("Can't able to find the Order.");
            }
        }

        [HttpPut("Discount/{restaurantID}/{productID}/{discount}")]
        public async Task<ActionResult> ChangeProductDiscount([FromRoute] Guid restaurantID, [FromRoute] Guid productID, [FromRoute][Range(0, 100)] double discount)
        {
            if (_dataProvider.Discount(restaurantID, productID, discount).Result)
            {
                return Ok("success");
            }
            else
            {
                return NotFound("Please recheck the entered fields");
            }
        }

        [HttpPatch("AddMenu/{RestaurantID}")]
        public async Task<ActionResult> AddMenuToTheRestaurant([Required] Guid RestaurantID, [FromBody] JsonPatchDocument<Menu> jsonPatchDocument)
        {
            var status = await _dataProvider.PatchMenuItems(RestaurantID, jsonPatchDocument);
            if (status != null)
            {
                var statusDTO = _mapper.Map<MenuDTO>(status);
                return Ok(statusDTO);
            }
            return BadRequest();
        }
    }
}