using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.CustomerManager
{
   public interface ICustomerManagerBL
    {
        Task<int> AddCustomerAddress(CustomerAdressCL address);
   
        CustomerAdressCL GetCustomerAddress(string email);
    }
}
