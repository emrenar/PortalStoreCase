
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
    public class EfSkuRepository : GenericRepository<SKU>, ISkuRepository
    {
        public EfSkuRepository(PortalDbContext context) : base(context)
        {
        }

        public async Task<List<SKU>> GetAllActiveSkuAsync()
        {
            var skuList = await _context.SKUs.Include(a=>a.Category).Where(x => x.Status == true).ToListAsync();
            return skuList;
        }
    }
}
