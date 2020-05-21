using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBussinessLayer.CustomerManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreCommonLayer;

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
        private readonly Sender sender = new Sender();
        private readonly ICustomerManagerBL imanager;
        public CustomerAddressController(ICustomerManagerBL imanager)
        {
            this.imanager = imanager;
        }

        /// <summary>
        /// Add Customer Address.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCustomerAddress(CustomerAdress address)
        {
            var result = await this.imanager.AddCustomerAddressBL(address);
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
        [HttpGet]
        public CustomerAdress GetCustomerAddress(string email)
        {
            sender.Send("Get all address");
            return this.imanager.GetCustomerAddressBL(email);
        }

    }
}