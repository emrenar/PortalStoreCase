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

namespace PortalStoreCase.Business.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task ChangeRecordStatusAsync(int id)
        {
            var order = await _repository.GetEntityByIdAsync(id);
            order.Status = false;
            _repository.SaveAsync();
        }

        public async Task<IList<OrderResponseDto>> GetAllActiveOrdersAsync()
        {
            var orders = await _repository.GetAllActiveOrderAsync();
            var orderListResponse = _mapper.Map<IList<OrderResponseDto>>(orders);
            return orderListResponse;
        }

        public async Task OrderProductAsync(OrderRequestDto orderRequestDto)
        {
            var order = _mapper.Map<Order>(orderRequestDto);
            _repository.Add(order);
            _repository.Save();
        }
    }
}
