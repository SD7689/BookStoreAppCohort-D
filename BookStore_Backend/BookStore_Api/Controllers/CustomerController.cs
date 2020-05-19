﻿using System;
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
        public CustomerAdress GetCustomerAddress(string Email_Id)
        {
            sender.Send("Get all address");
            return this.imanager.GetCustomerAddress(Email_Id);
        }

        /// <summary>
        /// Custmor login.
        /// </summary>
        /// <param name="Email_Id"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [Route("CustmorLogin")]
        [HttpGet]
        public object CustmorLogin(string Email_Id, string Password)
        {
            return this.imanager.Login(Email_Id, Password);
        }

    }
}