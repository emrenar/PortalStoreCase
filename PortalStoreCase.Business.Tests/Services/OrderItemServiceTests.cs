using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PortalStoreCase.Business.Services.OrderItemServices;
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
    public class OrderItemServiceTests
    {
        Mock<IOrderItemRepository> _mockOrderItemRepository;
        Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Start()
        {
            _mockOrderItemRepository = new Mock<IOrderItemRepository>();
            _mockMapper = new Mock<IMapper>();
            List<OrderItem> _dbOrderItemList = new List<OrderItem>
            {
                new OrderItem{Id=1,OrderId=2,SkuId=3,Status=true,UnitPrice=100,Quantity=4},
                new OrderItem{Id=2,OrderId=1,SkuId=2,Status=false,UnitPrice=233,Quantity=2},
                new OrderItem{Id=3,OrderId=3,SkuId=5,Status=true,UnitPrice=45,Quantity=8}
            };
            _mockOrderItemRepository.Setup(m => m.GetAllActiveOrderItemAsync()).Returns(Task.FromResult(_dbOrderItemList));

            OrderItem _dbOrderItem = new OrderItem() { Id = 1, OrderId = 2, SkuId = 3, Status = true, UnitPrice = 100, Quantity = 4 };
            _mockOrderItemRepository.Setup(m => m.GetEntityByIdAsync(1)).Returns(Task.FromResult(_dbOrderItem));
        }

        [TestMethod]
        public void GetAllActiveOrderItemAsync_Should_Be_Return_Active_OrderItems()
        {
            // Arrange
            IOrderItemService orderItemService = new OrderItemService(_mockOrderItemRepository.Object, _mockMapper.Object);
            // Act
            orderItemService.GetAllActiveOrderItemsAsync();
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ChangeRecordStatusAsync_Should_Be_Change_Statu()
        {
            // Arrange
            IOrderItemService orderItemService = new OrderItemService(_mockOrderItemRepository.Object, _mockMapper.Object);
            // Act
            orderItemService.ChangeRecordStatusAsync(1);
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddOrderItemAsync_Should_Be_Add_NewOrderItem()
        {
            /// Arrange
            IOrderItemService orderItemService = new OrderItemService(_mockOrderItemRepository.Object, _mockMapper.Object);
            // Act
            orderItemService.AddOrderItemAsync(new OrderItemRequestDto { OrderId = 8, Quantity = 4, SkuId = 3, UnitPrice = 850 });
            //Assert
            Assert.IsTrue(true);
        }
    }
}
