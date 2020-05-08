using BookStore_Api.Controllers;
using Manager.CustomerManager;
using Model;
using Moq;
using NUnit.Framework;
using Repository;
using Repository.CustomerRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestBookStoreProject
{
    public class AddressUnitTesing
    {
        CustomerAdress address = new CustomerAdress()
        {
          BookID=1,
          FullName="Imran",
          PhoneNumber=7847456,
          Email="Imr57@gmail.com",
          Address="gfe",
          Pincode=845,
          Citytown="frer",
          Landmark="jwhj"

        };
        [Test]
        public void AddAddressManagerTest()
        {
            var repo = new Mock<ICustomer>();
            var manager = new ImpCustomerManager(repo.Object);
           
            var data = manager.AddCustomerAddress(address);
            Assert.NotNull(data);
           
        }
    }
}
