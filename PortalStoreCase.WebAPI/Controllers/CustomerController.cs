using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreCase.Business.Services.CustomerServices;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using System.Threading.Tasks;

namespace PortalStoreCase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerService;

        public CustomerController(ICustomerServices customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("[action]")] 
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetAllActiveCustomersAsync();
            return Ok(customers);
        }

        [HttpPost("[action]")]
        public IActionResult CreateValidCustomer(CustomerRequestDto customerRequestcntrl)
        {
            _customerService.CreateCustomer(customerRequestcntrl);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> RemoveCustomerFromList(int id)
        {
            await _customerService.ChangeRecordStatusAsync(id);
            return Ok();
        }
    }
}
