using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.DTOs.ResponseDtos;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Services.CustomerServices
{
    public interface ICustomerServices
    {
        Task<IList<CustomerResponseDto>> GetAllActiveCustomersAsync();
        void CreateCustomer(CustomerRequestDto customerRequest);
        Task ChangeRecordStatusAsync(int id);
    }
}
