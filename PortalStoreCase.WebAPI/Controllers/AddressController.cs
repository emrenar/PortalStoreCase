using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreCase.Business.Services.AddressServices;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using System.Threading.Tasks;

namespace PortalStoreCase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetActiveAddresses()
        {
            var addresses = await _service.GetAllActiveAddressesAsync();
            return Ok(addresses);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> RemoveAddressFromList(int id)
        {
            await _service.ChangeRecordStatusAsync(id);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewAddress(AddressRequestDto addressRequestDto)
        {
            await _service.AddAddressAsync(addressRequestDto);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ChangeAddressValue(AddressRequestDto addressRequestDto)
        {
            await _service.ChangeAddressAsync(addressRequestDto);
            return Ok();
        }

    }
}
