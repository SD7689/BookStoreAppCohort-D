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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager imanager;
        public CustomerController(ICustomerManager imanager)
        {
            this.imanager = imanager;
        }

        /// <summary>
        /// Add Customer Address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [Route("AddCustomerAddress")]
        [HttpPost]
        public async Task<IActionResult> AddCustomerAddress(CustomerAdress address)
        {
            var result = await this.imanager.AddCustomerAddress(address);
            if (result == 1)
            {
                return this.Ok(address);
            }

            return this.BadRequest();
        }

    }
}