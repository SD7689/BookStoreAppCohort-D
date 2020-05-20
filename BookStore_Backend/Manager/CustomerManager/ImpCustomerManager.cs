﻿using Model;
using Repository.CustomerRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.CustomerManager
{
    public class ImpCustomerManager : ICustomerManager
    {
        private readonly ICustomer irepo;
        public ImpCustomerManager(ICustomer irepo)
        {
            this.irepo = irepo;
        }
        public Task<int> AddCustomerAddress(CustomerAdress address)
        {
            return this.irepo.AddCustomerAddress(address);
        }

        public CustomerAdress GetCustomerAddress(string Email_Id)
        {
            return this.irepo.GetCustomerAddress(Email_Id);
        }

        public CustomerAdress Login(string Email_Id, string Password)
        {
            return this.irepo.Login(Email_Id, Password);
        }

    }
}
