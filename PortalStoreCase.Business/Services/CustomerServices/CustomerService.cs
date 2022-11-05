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

namespace PortalStoreCase.Business.Services.CustomerServices
{
    public class CustomerService : ICustomerServices
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICustomerCheckService _checkService;


        public CustomerService(ICustomerRepository repository, IMapper mapper, ICustomerCheckService checkService)
        {
            _repository = repository;
            _mapper = mapper;
            _checkService = checkService;
        }

        public void CreateCustomer(CustomerRequestDto customerRequest)
        {
            if (_checkService.CheckIsRealPersonAsync(_mapper.Map<Customer>(customerRequest)).Result)
            {
                CustomerRequestDto customer = new CustomerRequestDto();
                customer.Birthdate = customerRequest.Birthdate;
                customer.Email = customerRequest.Email;
                customer.FirstName = customerRequest.FirstName;
                customer.LastName = customerRequest.LastName;
                customer.TCID = customerRequest.TCID;
                customer.Gsm = customerRequest.Gsm;

                _repository.Add(_mapper.Map<Customer>(customer));
                _repository.Save();
            }
            else
            {
                throw new Exception("Not a valid person");
            }
        }

        public async Task<List<CustomerResponseDto>> GetAllActiveCustomersAsync()
        {
            var customers = await _repository.GetAllActiveCustomerAsync();
            var customersListResponse = _mapper.Map<List<CustomerResponseDto>>(customers);
            return customersListResponse;
        }

        public async Task ChangeRecordStatusAsync(int id)
        {
            var customerInfo = await _repository.GetEntityByIdAsync(id);
            customerInfo.Status = false;
            _repository.SaveAsync();
        }
    }
}
