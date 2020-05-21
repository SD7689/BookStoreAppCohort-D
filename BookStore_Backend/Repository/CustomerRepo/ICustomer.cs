using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CustomerRepo
{
   public interface ICustomer
    {
        Task<int> AddCustomerAddress(CustomerAdress address);
        CustomerAdress GetCustomerAddress(int CustomerId);
        IQueryable Login(string Email, string Password);
    }
}
