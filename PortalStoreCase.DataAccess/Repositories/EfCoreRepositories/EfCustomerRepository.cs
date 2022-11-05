using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalStoreCase.DataAccess.Data;
using PortalStoreCase.DataAccess.Repositories.GenericRepositories;
using PortalStoreCase.DataAccess.Repositories.IRepositories;
using PortalStoreCase.Entities.DTOs.RequestDtos;
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
        private readonly IMapper _mapper;
        public EfCustomerRepository(PortalDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<Customer>> GetAllActiveCustomerAsync()
        {
            var listCustomer = await _context.Customers.Where(x => x.Status == true).ToListAsync();
            return listCustomer;
        }
    }
}
