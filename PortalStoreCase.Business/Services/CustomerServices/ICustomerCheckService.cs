using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Services.CustomerServices
{
    public interface ICustomerCheckService
    {
        Task<bool> CheckIsRealPersonAsync(Customer customer);
    }
}
