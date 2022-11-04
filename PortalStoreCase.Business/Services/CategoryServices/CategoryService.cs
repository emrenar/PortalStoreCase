using AutoMapper;
using PortalStoreCase.DataAccess.Repositories.IRepositories;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.DTOs.ResponseDtos;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddCategoryAsync(CategoryRequestDto categoryRequestDto)
        {
            var category = _mapper.Map<Category>(categoryRequestDto);
            _repository.Add(category);
            _repository.Save();
        }

        public async Task ChangeRecordStatusAsync(int id)
        {
            var category = await _repository.GetEntityByIdAsync(id);
            category.Status = false;
            _repository.SaveAsync();
        }

        public async Task<IList<CategoryResponseDto>> GetAllActiveCategoryAsync()
        {
            var categories = await _repository.GetAllActiveCategoryAsync();
            var categoriesListResponse = _mapper.Map<IList<CategoryResponseDto>>(categories);
            return categoriesListResponse;
        }

        public async Task<List<CategoryResponseDto>> GetAllCategories()
        {
            var categories =await _repository.GetAllAsync();
            var categoryResponse = _mapper.Map<List<CategoryResponseDto>>(categories);
            return categoryResponse;
        }

        public async Task<List<SkuResponseDto>> GetSingleCategoryByIdWithSkusService(int categoryId)
        {
            var listSku = await _repository.GetSingleCategoryByIdWithSkusAsync(categoryId);

            var listSkuDto = _mapper.Map<List<SkuResponseDto>>(listSku);

            return listSkuDto;
        }
    }
}
