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
    public class EfOrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public EfOrderItemRepository(PortalDbContext context) : base(context)
        {
        }

        public async Task<List<OrderItem>> GetAllActiveOrderItemAsync()
        {
            var listOrderItem = await _context.OrderItems.Include(a=>a.SKU).Where(x => x.Status == true).ToListAsync();
            return listOrderItem;
        }
    }
}
