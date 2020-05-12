using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.CustomerManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
        private readonly Sender sender = new Sender();
        private readonly ICustomerManager imanager;
        public CustomerAddressController(ICustomerManager imanager)
        {
            this.imanager = imanager;
        }

        /// <summary>
        /// Add Customer Address.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [Route("AddCustomerAddress")]
        [HttpPost]
        public async Task<IActionResult> AddCustomerAddress(CustomerAdress address)
        {
            var result = await this.imanager.AddCustomerAddress(address);
            sender.Send("Add custmor address");
            if (result == 1)
            {
                return this.Ok(address);
            }

            return this.BadRequest();
        }
        /// <summary>
        /// Add GetCustomerAddress 
        /// </summary>
        /// <param name="enterAddres"></param>
        /// <returns></returns>
        [Route("GetCustomerAddress")]
        [HttpGet]
<<<<<<< HEAD:BookStore_Backend/BookStore_Api/Controllers/CustomerController.cs
        public CustomerAdress GetCustomerAddress(int addressId)
        {
            sender.Send("Get all address");
            return this.imanager.GetCustomerAddress(addressId);
=======
        public CustomerAdress GetCustomerAddress(string email)
        {
            sender.Send("Get all address");
            return this.imanager.GetCustomerAddress(email);
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a:BookStore_Backend/BookStore_Api/Controllers/CustomerAddressController.cs
        }

    }
}