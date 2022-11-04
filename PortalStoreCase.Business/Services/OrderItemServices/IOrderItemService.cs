using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.DTOs.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Services.OrderItemServices
{
    public interface IOrderItemService
    {
        Task<IList<OrderItemResponseDto>> GetAllActiveOrderItemsAsync();
        Task ChangeRecordStatusAsync(int id);
        Task AddOrderItemAsync(OrderItemRequestDto orderItemRequestDto);
    }
}
