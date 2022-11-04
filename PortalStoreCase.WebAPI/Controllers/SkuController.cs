using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreCase.Business.Services.SkuServices;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using System.Threading.Tasks;

namespace PortalStoreCase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkuController : ControllerBase
    {
        private readonly ISkuService _skuService;

        public SkuController(ISkuService skuService)
        {
            _skuService = skuService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetActiveSkus()
        {
            var skus = await _skuService.GetAllActiveSkuAsync();
            return Ok(skus);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> RemoveSkuFromList(int id)
        {
            await _skuService.ChangeRecordStatusAsync(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddSku(SkuRequestDto skuRequestDto)
        {
            _skuService.AddSkuAsync(skuRequestDto);
            return Ok();
        }
    }
}
