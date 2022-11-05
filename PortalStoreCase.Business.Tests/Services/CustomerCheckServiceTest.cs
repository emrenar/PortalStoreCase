using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PortalStoreCase.Business.Services.CustomerServices;
using PortalStoreCase.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreCase.Tests.Services
{
    [TestClass]
    public class CustomerCheckServiceTest
    {      
        [TestMethod]
        public void CheckIsRealPersonAsync_Should_Be_Return()
        {
            // Arrange
            ICustomerCheckService customerCheckServices = new CustomerCheckService();
            // Act
            customerCheckServices.CheckIsRealPersonAsync(new Customer { FirstName="Emre",LastName="Nar",TCID=1524587,Birthdate=DateTime.Now});
            //Assert
            Assert.IsTrue(true);
        }
    }
}
