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
          FullName="Itr",
          PhoneNumber=7847456,
          Email="Imr57@gmail.com",
          Address="ABC",
          Pincode=845,
          Citytown="MTY",
          Landmark="BTM"

        };
        [Test]
        public void AddAddressManagerTest()
        {
            var repo = new Mock<ICustomer>();
            var manager = new ImpCustomerManager(repo.Object);
           
            var data = manager.AddCustomerAddress(address);
            Assert.NotNull(data);
           
        }
        [Test]
        public void AddAddressControllerTest()
        {
            var service = new Mock<ICustomerManager>();
            var controller = new CustomerAddressController(service.Object);
            var data = controller.AddCustomerAddress(address);
            Assert.IsNotNull(data);
        }

        
    }
}
