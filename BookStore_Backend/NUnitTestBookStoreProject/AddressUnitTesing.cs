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
        CustomerCL address = new CustomerCL()
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
        public void GivenAddressDetail_CustomerAddressBL_ShouldReturnAddress()
        {
            var repo = new Mock<ICustomerRL>();
            var manager = new ImpCustomerManagerBL(repo.Object);
           
            var data = manager.AddCustomerAddress(address);
            Assert.NotNull(data);
           
        }
        [Test]
        public void GivenAddressDetail_CustomerAddressController_ShouldReturnAddress( )
        {
            var service = new Mock<ICustomerManagerBL>();
            var controller = new CustomerAddressController(service.Object);
            var data = controller.AddCustomerAddress(address);
            Assert.IsNotNull(data);
        }

        
    }
}
