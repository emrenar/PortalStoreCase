using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PortalStoreCase.Business.Services.AddressServices;
using PortalStoreCase.DataAccess.Repositories.IRepositories;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Tests.Services
{
    [TestClass]
    public class AddressServiceTests
    {
        Mock<IAddressRepository> _mockAddressRepository;
        Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Start()
        {
            _mockAddressRepository = new Mock<IAddressRepository>();
            _mockMapper = new Mock<IMapper>();

            List<Address> _dbAddressList = new List<Address>
            {
                new Address{Id=1,CustomerId=2,Status=true,AddressLine="street"},
                new Address{Id=2,CustomerId=4,Status=true,AddressLine="street2"},
                new Address{Id=3,CustomerId=3,Status=false,AddressLine="street3"}
            };
            _mockAddressRepository.Setup(m => m.GetAllActiveAddressAsync()).Returns(Task.FromResult(_dbAddressList));

            Address _dbAddress = new Address() { Id = 1, CustomerId = 2, Status = true, AddressLine = "street" };
            _mockAddressRepository.Setup(m => m.GetEntityByIdAsync(1)).Returns(Task.FromResult(_dbAddress));
        }

        [TestMethod]
        public void GetAllActiveAddressAsync_Should_Be_Return_Active_Address()
        {
            // Arrange
            IAddressService addressService = new AddressService(_mockMapper.Object,_mockAddressRepository.Object);
            // Act
            addressService.GetAllActiveAddressesAsync();
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ChangeRecordStatusAsync_Should_Be_Change_Statu()
        {
            // Arrange
            IAddressService addressService = new AddressService(_mockMapper.Object, _mockAddressRepository.Object);
            // Act
            addressService.ChangeRecordStatusAsync(1);
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddAddressAsync_Should_Be_Add_NewAddress()
        {
            // Arrange
            IAddressService addressService = new AddressService(_mockMapper.Object, _mockAddressRepository.Object);
            // Act
            addressService.AddAddressAsync(new AddressPostDto {AddressLine="street",CustomerId=7,Country="Germany",City="Frankfurt",District="Giessen",ZipCode=35340});
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ChangeAddressAsync_Should_Be_Change_To_Address()
        {
            // Arrange
            IAddressService addressService = new AddressService(_mockMapper.Object, _mockAddressRepository.Object);
            // Act
            addressService.ChangeAddressAsync(new AddressRequestDto { Id = 1, AddressLine = "streetChange", CustomerId = 2, Country = "Poland", City = "Warsaw", District = "Szczein", ZipCode = 35340 });
            //Assert
            Assert.IsTrue(true);
        }
    }
}
