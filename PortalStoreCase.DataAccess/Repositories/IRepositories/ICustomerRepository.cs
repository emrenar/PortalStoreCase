using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.DataAccess.Repositories.IRepositories
{
    public interface ICustomerRepository:IRepository<Customer> 
    {
        Task<List<Customer>> GetAllActiveCustomerAsync();
    }
}
