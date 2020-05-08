using BookStore_Api.Controllers;
using Manager.CustomerManager;
using Moq;
using NUnit.Framework;
using Repository.CustomerRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestBookStoreProject
{
    public class AddressUnitTesing
    {
        /// <summary>
        /// GetAddress_ShouldReturnAddress
        /// </summary>
        [Test]
        public void GetAddress_ShouldReturnAddress()
        {
            var service = new Mock<ICustomerManager>();
            var Controller = new CustomerController(service.Object);
           var data= Controller.GetCustomerAddress(1);
            Assert.IsNotNull(data);
        }
        /// <summary>
        /// GetAddressManagerTest
        /// </summary>
        [Test]
        public void GetAddressManagerTest()
        {
            var repo = new Mock<ICustomer>();
            var manager = new ImpCustomerManager(repo.Object);

            var data = manager.GetCustomerAddress(1);
            Assert.NotNull(data);

        }

    }
}
