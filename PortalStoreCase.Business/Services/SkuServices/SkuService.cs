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

namespace PortalStoreCase.Business.Services.SkuServices
{
    public class SkuService : ISkuService
    {
        private readonly ISkuRepository _repository;
        private readonly IMapper _mapper;

        public SkuService(ISkuRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task ChangeRecordStatusAsync(int id)
        {
            var sku = await _repository.GetEntityByIdAsync(id);
            sku.Status = false;
            _repository.SaveAsync();
        }

        public async Task<List<SkuResponseDto>> GetAllActiveSkuAsync()
        {
            var skuList = await _repository.GetAllActiveSkuAsync();
            var skuDto = _mapper.Map<List<SkuResponseDto>>(skuList);
            return skuDto;
        }

        public async Task AddSkuAsync(SkuRequestDto skuRequest)
        {
            var sku = _mapper.Map<SKU>(skuRequest);
            _repository.Add(sku);
            _repository.Save();
        }
    }
}
