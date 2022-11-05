using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.DTOs.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Services.SkuServices
{
    public interface ISkuService
    {
        Task<List<SkuResponseDto>> GetAllActiveSkuAsync();
        Task ChangeRecordStatusAsync(int id);
        Task AddSkuAsync(SkuRequestDto skuRequest);
    }
}
