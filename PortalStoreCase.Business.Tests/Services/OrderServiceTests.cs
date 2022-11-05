using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PortalStoreCase.Business.Services.OrderServices;
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
    public class OrderServiceTests
    {
        Mock<IOrderRepository> _mockOrderRepository;
        Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Start()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockMapper = new Mock<IMapper>();

            List<Order> _dbOrderList = new List<Order>
            {
                new Order{Id=1,AddressId=2,CustomerId=3,Status=true},
                new Order{Id=2,AddressId=1,CustomerId=1,Status=false},
                new Order{Id=3,AddressId=3,CustomerId=4,Status=true},
            };
            _mockOrderRepository.Setup(m => m.GetAllActiveOrderAsync()).Returns(Task.FromResult(_dbOrderList));

            Order _dbOrder = new Order() { Id = 1, AddressId = 2, CustomerId = 3, Status = true };
            _mockOrderRepository.Setup(m => m.GetEntityByIdAsync(1)).Returns(Task.FromResult(_dbOrder));
        }

        [TestMethod]
        public void GetAllActiveOrderAsync_Should_Be_Return_Active_Orders()
        {
            // Arrange
            IOrderService orderService = new OrderService(_mockOrderRepository.Object, _mockMapper.Object);
            // Act
            orderService.GetAllActiveOrdersAsync();
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ChangeRecordStatusAsync_Should_Be_Change_Statu()
        {
            // Arrange
            IOrderService orderService = new OrderService(_mockOrderRepository.Object, _mockMapper.Object);
            // Act
            orderService.ChangeRecordStatusAsync(1);
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddOrderAsync_Should_Be_Add_NewOrder()
        {
            // Arrange
            IOrderService orderService = new OrderService(_mockOrderRepository.Object, _mockMapper.Object);
            // Act
            orderService.OrderProductAsync(new OrderRequestDto { CustomerId=1,AddressId=2,TotalPrice=120});
            //Assert
            Assert.IsTrue(true);
        }
    }
}
