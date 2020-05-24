using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Manager.CustomerManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class CustomerController : ControllerBase
    {
        private readonly Sender sender = new Sender();
        private readonly ICustomerManager imanager;

        public CustomerController(ICustomerManager imanager)
        {
            this.imanager = imanager;
        }

        /// <summary>
        /// Add Customer Address.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        // [Route("Customer details")]
        [HttpPost]
        public async Task<IActionResult> AddCustomerAddress(CustomerAdress address)
        {
            try
            {
                var result = await this.imanager.AddCustomerAddress(address);
                sender.Send("Add custmor address");
                return this.Ok(address);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Server_Error = "This email id already used" });
            }
        }

                /// <summary>
                /// Add GetCustomerAddress 
                /// </summary>
                /// <param name="enterAddres"></param>
                /// <returns></returns>
                //[Route("Its show the customer details")]
                [HttpGet]
        public IActionResult GetCustomerAddress(int CustomerId)
        {
            sender.Send(" Its show the all customer details ");
            var result = this.imanager.GetCustomerAddress(CustomerId);
            if (result != null)
                return this.Ok(result);

            return StatusCode(400, new { Result = "This id details not present in database" });
        }
        

        /// <summary>
        /// Custmor login.
        /// </summary>
        /// <param name="Email_Id"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [Route("UserLogin")]
        [HttpGet]
        public IActionResult CustmorLogin(string Email_Id, string Password)
        {
            var result = this.imanager.Login(Email_Id, Password);
            if (result != null)
                return this.Ok(result);
            return StatusCode(400, new { Result= "Please enter the valid email id and password" });
        }
    }
}