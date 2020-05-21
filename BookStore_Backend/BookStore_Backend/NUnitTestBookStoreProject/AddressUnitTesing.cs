﻿using BookStore_Api.Controllers;
using Manager.CustomerManager;
using Moq;
using NUnit.Framework;

using Model;
using Repository;
using Repository.CustomerRepo;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace NUnitTestBookStoreProject
{
    public class AddressUnitTesing
    {
       
        CustomerAdressCL address = new CustomerAdressCL()
        {
          FullName="Imran",
          PhoneNumber="7847456",
          Email="Imr57@gmail.com",
          Address="ABC",
          Pincode=845,
          Citytown="MTY",
          Landmark="BTM"

        };
       
        [Test]
        public void AddAddressManagerTest()
        {
            var repo = new Mock<ICustomerRL>();
            var manager = new ImpCustomerManagerBL(repo.Object);
           
            var data = manager.AddCustomerAddress(address);
            Assert.NotNull(data);
           
        }
        [Test]
        public void AddAddressControllerTest()
        {
            var service = new Mock<ICustomerManagerBL>();
            var controller = new CustomerAddressController(service.Object);
            var data = controller.AddCustomerAddress(address);

            Assert.IsNotNull(data);
        }

       
    }
}
