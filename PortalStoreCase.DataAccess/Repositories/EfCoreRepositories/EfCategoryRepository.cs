using Microsoft.EntityFrameworkCore;
using PortalStoreCase.DataAccess.Data;
using PortalStoreCase.DataAccess.Repositories.GenericRepositories;
using PortalStoreCase.DataAccess.Repositories.IRepositories;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.DataAccess.Repositories.EfCoreRepositories
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(PortalDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetAllActiveCategoryAsync()
        {
            var listCategory = await _context.Categories.Where(x => x.Status == true).ToListAsync();
            return listCategory;
        }

        public async Task<List<SKU>> GetSingleCategoryByIdWithSkusAsync(int categoryId)
        {
            var category = await _context.Categories.Include(x => x.SKUs).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
            var products = await _context.SKUs.Where(x => x.CategoryId == category.Id).ToListAsync();
            return products;
        }
    }
}
