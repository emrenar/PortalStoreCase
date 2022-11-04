using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreCase.Business.Services.OrderServices;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using System.Threading.Tasks;

namespace PortalStoreCase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetActiveOrders()
        {
            var orders = await _service.GetAllActiveOrdersAsync();
            return Ok(orders);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> RemoveOrderFromList(int id)
        {
            await _service.ChangeRecordStatusAsync(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult MakeAnOrder(OrderRequestDto orderRequestDto)
        {
            _service.OrderProductAsync(orderRequestDto);
            return Ok();
        }
    }
}
