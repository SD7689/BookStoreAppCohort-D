﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.CustomerRepo
{
   public interface ICustomer
    {
        Task<int> AddCustomerAddress(CustomerAdress address);
        CustomerAdress GetCustomerAddress(string email);
    }
}
