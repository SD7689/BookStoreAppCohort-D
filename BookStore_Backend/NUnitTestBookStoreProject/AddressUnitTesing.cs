using BookStore_Api.Controllers;
using Manager.CustomerManager;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestBookStoreProject
{
    public class AddressUnitTesing
    {
        [Test]
        public void GetAddress_ShouldReturnAllAddress()
        {
            var service = new Mock<ICustomerManager>();
            var Controller = new CustomerController(service.Object);
            Controller.GetCustomerAddress(1);
            Assert.IsNotNull(1);
        }

    }
}
