using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.DTOs.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Services.OrderServices
{
    public interface IOrderService
    {
        Task<IList<OrderResponseDto>> GetAllActiveOrdersAsync();
        Task ChangeRecordStatusAsync(int id);
        Task OrderProductAsync(OrderRequestDto orderRequestDto);
    }
}
