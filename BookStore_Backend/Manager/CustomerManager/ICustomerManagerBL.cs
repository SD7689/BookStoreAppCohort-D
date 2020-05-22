using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.CustomerManager
{
   public interface ICustomerManagerBL
    {
        Task<int> AddCustomerAddress(CustomerCL address);
        CustomerCL GetCustomerAddress(string email);
    }
}
