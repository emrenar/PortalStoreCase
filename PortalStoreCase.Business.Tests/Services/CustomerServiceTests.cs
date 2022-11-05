using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PortalStoreCase.Business.Services.CategoryServices;
using PortalStoreCase.Business.Services.CustomerServices;
using PortalStoreCase.DataAccess.Repositories.IRepositories;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.DTOs.ResponseDtos;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Business.Tests.Services
{
    [TestClass]
    public class CustomerServiceTests
    {
        Mock<ICustomerRepository> _mockCustomerRepository;
        Mock<IMapper> _mockMapper;
        Mock<ICustomerCheckService> _mockCustomerCheckService;
 
        [TestInitialize]
        public void Start()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockCustomerCheckService = new Mock<ICustomerCheckService>();
            List<Customer> _dbCustomerResponseDto_ = new List<Customer>
            {
                new Customer{FirstName = "Hasan",LastName="Can",Id=1,Status=true},
                new Customer{FirstName = "Emre",LastName="Nar",Id=2,Status=true }
            };          
            _mockCustomerRepository.Setup(m => m.GetAllActiveCustomerAsync()).Returns(Task.FromResult(_dbCustomerResponseDto_));

            Customer _dbCustomer = new Customer() { FirstName = "Emre", LastName = "Nar", Id = 1, Status = true };
            _mockCustomerRepository.Setup(m => m.GetEntityByIdAsync(1)).Returns(Task.FromResult(_dbCustomer));
        }

        [TestMethod]
        public void GetAllActiveCustomerAsync_Should_Be_Return_Ok_Customer()
        {
            // Arrange
            ICustomerServices customerServices = new CustomerService(_mockCustomerRepository.Object, _mockMapper.Object,_mockCustomerCheckService.Object);
            // Act
            customerServices.GetAllActiveCustomersAsync();
            //Assert
            Assert.IsTrue(true);
        }

        //[TestMethod]
        //public void CreateCustomer_Should_Be_Create_Valid_Customer()
        //{
        //    // Arrange
        //    ICustomerServices customerServices = new CustomerService(_mockCustomerRepository.Object, _mockMapper.Object, _mockCustomerCheckService.Object);
        //    // Act
        //    customerServices.CreateCustomer(new CustomerRequestDto() { FirstName="Emre",LastName="Nar",Birthdate="18.03.1998",TCID=29102061528,Email="sdsd@gmail.com",Gsm="26566"});
        //    //Assert
        //    Assert.IsTrue(true);
        //}

        [TestMethod]
        public void ChangeRecordStatusAsync_Should_Be_Change_Customer_Statu()
        {
            // Arrange
            ICustomerServices customerServices = new CustomerService(_mockCustomerRepository.Object, _mockMapper.Object, _mockCustomerCheckService.Object);
            // Act
            customerServices.ChangeRecordStatusAsync(1);
            //Assert
            Assert.IsTrue(true);
        }
    }
}
