using Manager.CustomerManager;
using Model;
using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace BookStoreXUnitTesting
{
    public class UnitTest1
    {
        CustomerAdress addres;
        [Fact]
        public async TaskMethodBuilder Test1()
        {
            addres.Citytown = "jhjghg";
            addres.Email = "dhkfgfj";
            addres.FullName = "fdfulb";
            addres.Landmark = "bxbjygyj";
            addres.PhoneNumber = 3546;
            addres.Pincode = 224132;
            addres.Address = "tsyjhbkjhlkjlj";
            var service = new Mock<ICustomerManager>();
            var controller = new CustomerController(service.Object);
            var data = await controller.AddCustomerAddress(addres);
        }
    }
}
