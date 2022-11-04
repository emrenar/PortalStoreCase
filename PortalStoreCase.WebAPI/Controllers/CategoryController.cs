using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStoreCase.Business.Services.CategoryServices;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using System.Threading.Tasks;

namespace PortalStoreCase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSkusByCategoryId(int categoryId)
        {
            return Ok(await _categoryService.GetSingleCategoryByIdWithSkusService(categoryId));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetActiveCategories()
        {
            var categories = await _categoryService.GetAllActiveCategoryAsync();
            return Ok(categories);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> RemoveCategoryFromList(int id)
        {
            await _categoryService.ChangeRecordStatusAsync(id);
            return Ok();
        }
        [HttpPost("[action]")]
        public IActionResult CreateCategory(CategoryRequestDto categoryRequestDto)
        {
            _categoryService.AddCategoryAsync(categoryRequestDto);
            return Ok();
        }
    }
}
