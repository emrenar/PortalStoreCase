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
    public class EfOrderRespository : GenericRepository<Order>, IOrderRepository
    {
        public EfOrderRespository(PortalDbContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetAllActiveOrderAsync()
        {
            var listOrder = await _context.Orders.Include(a=>a.Customer).Include(z=>z.Address).Where(x => x.Status == true).ToListAsync();
            return listOrder;
        }
    }
}
