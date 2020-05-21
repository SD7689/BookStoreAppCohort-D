using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.CustomerManager
{
   public interface ICustomerManager
    {
        Task<int> AddCustomerAddress(CustomerAdress address);
        CustomerAdress GetCustomerAddress(int CustomerId);
        IQueryable Login(string Email, string Password);
    }
}
