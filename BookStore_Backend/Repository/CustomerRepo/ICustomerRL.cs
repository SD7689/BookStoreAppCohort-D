using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CustomerRepo
{
   public interface ICustomerRL
    {
        Task<int> AddCustomerAddress(CustomerCL address);
        CustomerCL GetCustomerAddress(string email);
    }
}
