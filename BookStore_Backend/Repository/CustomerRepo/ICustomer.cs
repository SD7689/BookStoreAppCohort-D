using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CustomerRepo
{
   public interface ICustomer
    {
        Task<int> AddCustomerAddress(CustomerAdress address);
        CustomerAdress GetCustomerAddress(int bookId);
    }
}
