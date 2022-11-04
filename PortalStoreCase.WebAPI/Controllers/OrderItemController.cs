using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreCase.Business.Services.OrderItemServices;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using System.Threading.Tasks;

namespace PortalStoreCase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _service;

        public OrderItemController(IOrderItemService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetActiveOrderItems()
        {
            var orderItems = await _service.GetAllActiveOrderItemsAsync();
            return Ok(orderItems);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> RemoveOrderItemFromList(int id)
        {
            await _service.ChangeRecordStatusAsync(id);
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrderItem(OrderItemRequestDto orderItemRequestDto)
        {
            await _service.AddOrderItemAsync(orderItemRequestDto);
            return Ok();
        }
    }
}
