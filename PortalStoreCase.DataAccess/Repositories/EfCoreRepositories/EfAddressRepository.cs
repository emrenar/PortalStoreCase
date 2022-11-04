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
    public class EfAddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public EfAddressRepository(PortalDbContext context) : base(context)
        {
        }

        public async Task<List<Address>> GetAllActiveAddressAsync()
        {
            var listAddress = await _context.Addresses.Include(a=>a.Customer).Where(x => x.Status == true).ToListAsync();
            return listAddress;
        }
    }
}
