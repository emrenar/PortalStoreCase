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
        Task<List<AddressResponseDto>> GetAllActiveAddressesAsync();
        Task ChangeRecordStatusAsync(int id);
        Task AddAddressAsync(AddressPostDto addressPostDto);
        Task ChangeAddressAsync(AddressRequestDto addressRequestDto);
    }
}
