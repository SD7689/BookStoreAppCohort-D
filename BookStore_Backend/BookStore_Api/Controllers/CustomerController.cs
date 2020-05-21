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
        //[Route("Customer details")]
        [HttpPost]
        public async Task<IActionResult> AddCustomerAddress(CustomerAdress address)
        {
            var result = await this.imanager.AddCustomerAddress(address);
            sender.Send("Add custmor address");
            if (result == 1)
            {
                return this.Ok(address);
            }
            return this.BadRequest("Incorrect data");
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
            return this.BadRequest("Enter the correct custmor id");
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
            return this.BadRequest("Please enter the valid email id and password");
        }

    }
}