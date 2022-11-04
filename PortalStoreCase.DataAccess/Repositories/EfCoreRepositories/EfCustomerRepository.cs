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
    public class EfCustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public EfCustomerRepository(PortalDbContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetAllActiveCustomerAsync()
        {
            var listCustomer = await _context.Customers.Where(x => x.Status == true).ToListAsync();
            return listCustomer;
        }
    }
}
