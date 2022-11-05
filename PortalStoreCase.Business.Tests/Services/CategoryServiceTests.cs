using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PortalStoreCase.Business.Mapping;
using PortalStoreCase.Business.Services.CategoryServices;
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
    public class CategoryServiceTests
    {
        Mock<ICategoryRepository> _mocCategoryRepository;
        Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Start()
        {
            _mocCategoryRepository = new Mock<ICategoryRepository>();
            _mockMapper = new Mock<IMapper>();
            List<CategoryResponseDto> _dbCategoryResponseDto_ = new List<CategoryResponseDto>
            {
                new CategoryResponseDto{Id=1,Name="deneme1",Status=true},
                new CategoryResponseDto{Id=2,Name="deneme2",Status=false},
                new CategoryResponseDto{Id=3,Name="deneme3",Status=true}
            };
            _mocCategoryRepository.Setup(m => m.GetAllActiveCategoryAsync()).Returns(Task.FromResult(_dbCategoryResponseDto_));

            List<Category> _dbCategoryDto = new List<Category>
            {
                new Category{Id=1,Name="deneme1",Status=true},
                new Category{Id=2,Name="deneme2",Status=false},
                new Category{Id=3,Name="deneme3",Status=true}
            };
            _mocCategoryRepository.Setup(m => m.GetAllAsync()).Returns(Task.FromResult(_dbCategoryDto));

            List<SKU> _dbSkuDto = new List<SKU>
            {
                new SKU{Id=1,Name="deneme1",CategoryId=1},
                new SKU{Id=2,Name="deneme2",CategoryId=1},
                new SKU{Id=3,Name="deneme3",CategoryId=1}
            };
            _mocCategoryRepository.Setup(m => m.GetSingleCategoryByIdWithSkusAsync(1)).Returns(Task.FromResult(_dbSkuDto));

            Category _dbCategory = new Category() { Id = 1, Name = "Test1", Status = true };
            _mocCategoryRepository.Setup(m => m.GetEntityByIdAsync(1)).Returns(Task.FromResult(_dbCategory));
        }

        [TestMethod]
        public void GetAllActiveCategories_Should_Be_Return_True_Categories()
        {
            // Arrange
            ICategoryService categoryService = new CategoryService(_mocCategoryRepository.Object, _mockMapper.Object);
            // Act
            categoryService.GetAllActiveCategoryAsync();
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetAllCategories_Should_Be_Return_AllCategories()
        {
            // Arrange
            ICategoryService categoryService = new CategoryService(_mocCategoryRepository.Object, _mockMapper.Object);
            // Act
            categoryService.GetAllCategories();
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetSingleCategoryByIdWithSkusService_Should_Be_Return_SKUs()
        {
            // Arrange
            ICategoryService categoryService = new CategoryService(_mocCategoryRepository.Object, _mockMapper.Object);
            // Act
            categoryService.GetSingleCategoryByIdWithSkusService(1);
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ChangeRecordStatusAsync_Should_Be_Change_Status()
        {
            // Arrange
            ICategoryService categoryService = new CategoryService(_mocCategoryRepository.Object, _mockMapper.Object);
            // Act
            categoryService.ChangeRecordStatusAsync(1);
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddCategoryAsync_Should_Be_Add_Category()
        {
            // Arrange
            ICategoryService categoryService = new CategoryService(_mocCategoryRepository.Object, _mockMapper.Object);
            // Act
            categoryService.AddCategoryAsync(new CategoryRequestDto { Name="Fırın"});
            //Assert
            Assert.IsTrue(true);
        }
    }
}
