using AutoMapper;
using PortalStoreCase.DataAccess.Repositories.IRepositories;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.DTOs.ResponseDtos;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Services.OrderItemServices
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddOrderItemAsync(OrderItemRequestDto orderItemRequestDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemRequestDto);
            _repository.Add(orderItem);
            _repository.SaveAsync();
        }

        public async Task ChangeRecordStatusAsync(int id)
        {
            var orderItem = await _repository.GetEntityByIdAsync(id);
            orderItem.Status = false;
            _repository.SaveAsync();
        }

        public async Task<IList<OrderItemResponseDto>> GetAllActiveOrderItemsAsync()
        {
            var orderItems = await _repository.GetAllActiveOrderItemAsync();
            var orderItemtResponse = _mapper.Map<IList<OrderItemResponseDto>>(orderItems);
            return orderItemtResponse;
        }
    }
}
