using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.DTOs.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDto>> GetAllCategories();
        Task<IList<CategoryResponseDto>> GetAllActiveCategoryAsync();
        Task ChangeRecordStatusAsync(int id);
        Task AddCategoryAsync(CategoryRequestDto categoryRequestDto);
        Task<List<SkuResponseDto>> GetSingleCategoryByIdWithSkusService(int categoryId);
    }
}
