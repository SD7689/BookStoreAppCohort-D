using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CustomerRepo
{
   public interface ICustomerRL
    {
        Task<int> AddCustomerAddress(CustomerAdressCL address);
   
        CustomerAdressCL GetCustomerAddress(string email);
    }
}
