using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.DTOs.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Services.AddressServices
{
    public interface IAddressService
    {
        Task<IList<AddressResponseDto>> GetAllActiveAddressesAsync();
        Task ChangeRecordStatusAsync(int id);
        Task AddAddressAsync(AddressRequestDto addressRequestDto);
        Task ChangeAddressAsync(AddressRequestDto addressRequestDto);
    }
}
