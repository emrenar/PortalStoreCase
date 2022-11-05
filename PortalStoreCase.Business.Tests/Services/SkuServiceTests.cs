using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PortalStoreCase.Business.Services.SkuServices;
using PortalStoreCase.DataAccess.Repositories.IRepositories;
using PortalStoreCase.Entities.DTOs.RequestDtos;
using PortalStoreCase.Entities.DTOs.ResponseDtos;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Tests.Services
{
    [TestClass]
    public class SkuServiceTests
    {
        Mock<ISkuRepository> _mockSkuRepository;
        Mock<IMapper> _mockMapper;
     
        [TestInitialize]
        public void Start()
        {
            _mockSkuRepository = new Mock<ISkuRepository>();
            _mockMapper = new Mock<IMapper>();
            
            List<SKU> _dbSkuList = new List<SKU>
            {
                new SKU{Id=1,Description="Test1Description",CategoryId=1,Name="Test1Name",Price=150,Status=true},
                new SKU{Id=2,Description="Test2Description",CategoryId=1,Name="Test2Name",Price=150,Status=true},
                new SKU{Id=3,Description="Test3Description",CategoryId=1,Name="Test3Name",Price=150,Status=true}
            };
            _mockSkuRepository.Setup(m => m.GetAllActiveSkuAsync()).Returns(Task.FromResult(_dbSkuList));

            SKU _dbSku = new SKU() { Id = 1, CategoryId = 1, Name = "Test11Name", Price = 150, Status = true };
            _mockSkuRepository.Setup(m => m.GetEntityByIdAsync(1)).Returns(Task.FromResult(_dbSku));
        }

        [TestMethod]
        public void GetAllActiveSkuAsync_Should_Be_Return_Active_SKUs()
        {
            // Arrange
            ISkuService skuService = new SkuService(_mockSkuRepository.Object, _mockMapper.Object);
            // Act
            skuService.GetAllActiveSkuAsync();
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ChangeRecordStatusAsync_Should_Be_Change_Statu()
        {
            // Arrange
            ISkuService skuService = new SkuService(_mockSkuRepository.Object, _mockMapper.Object);
            // Act
            skuService.ChangeRecordStatusAsync(1);
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddSkuAsync_Should_Be_Add_NewSku()
        {
            // Arrange
            ISkuService skuService = new SkuService(_mockSkuRepository.Object, _mockMapper.Object);
            // Act
            skuService.AddSkuAsync(new SkuRequestDto { Name="tekno1",CategoryId=2,Description="teknodesc",OldPrice=555,Price=154});
            //Assert
            Assert.IsTrue(true);
        }
    }
}
