using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.DataAccess.Repositories.IRepositories
{
    public interface ISkuRepository : IRepository<SKU>
    {
        Task<List<SKU>> GetAllActiveSkuAsync();
    }
}
