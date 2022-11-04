using PortalStoreCase.Entities.DTOs.ResponseDtos;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.DataAccess.Repositories.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAllActiveCategoryAsync();
        Task<List<SKU>> GetSingleCategoryByIdWithSkusAsync(int categoryId);
    }
}
