using BookStore_Api.Controllers;
using Manager.CustomerManager;
<<<<<<< HEAD

using Moq;
using NUnit.Framework;

using Model;
using Repository;

=======
using Model;
using Moq;
using NUnit.Framework;
using Repository;
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a
using Repository.CustomerRepo;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace NUnitTestBookStoreProject
{
    public class AddressUnitTesing
    {
<<<<<<< HEAD

       

        CustomerAdress address = new CustomerAdress()
        { 
          
          FullName="Aythhgg",
          PhoneNumber=7847456,
          Email="ff57@gmail.com",
=======
        CustomerAdress address = new CustomerAdress()
        {
          FullName="Imran",
          PhoneNumber=7847456,
          Email="Imr57@gmail.com",
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a
          Address="ABC",
          Pincode=845,
          Citytown="MTY",
          Landmark="BTM"

        };
<<<<<<< HEAD
       
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
            var controller = new CustomerController(service.Object);
            var data = controller.AddCustomerAddress(address);

            Assert.IsNotNull(data);
        }

        /// <summary>
        /// GetAddress_ShouldReturnAddress
        /// </summary>
        [Test]
        public void GetAddress_ShouldReturnAddress()
        {
            var service = new Mock<ICustomerManager>();
            var controller = new CustomerController(service.Object);

            CustomerAdress data = controller.GetCustomerAddress(1);
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
            Assert.IsNotNull(data);

        }
        //public List<CustomerAdress> GetAddress(int bookId)
        //{
        //    List<CustomerAdress> lit = new List<CustomerAdress>(); 
        //    var result=this.
        //}

=======
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
        
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a
    }
}
