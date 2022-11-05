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

namespace PortalStoreCase.Business.Services.AddressServices
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public AddressService(IMapper mapper, IAddressRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task AddAddressAsync(AddressPostDto addressPostDto)
        {
            var address = _mapper.Map<Address>(addressPostDto);
            _repository.Add(address);
            _repository.SaveAsync();
        }

        public async Task ChangeAddressAsync(AddressRequestDto addressRequestDto)
        {
            var address = _mapper.Map<Address>(addressRequestDto);
            _repository.Update(address);
            _repository.SaveAsync();
        }

        public async Task ChangeRecordStatusAsync(int id)
        {
            var address = await _repository.GetEntityByIdAsync(id);
            address.Status = false;
            _repository.SaveAsync();
        }

        public async Task<List<AddressResponseDto>> GetAllActiveAddressesAsync()
        {
            var addresses = await _repository.GetAllActiveAddressAsync();
            var addressesListResponse = _mapper.Map<List<AddressResponseDto>>(addresses);
            return addressesListResponse;
        }
    }
}
