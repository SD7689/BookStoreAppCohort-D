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
<<<<<<< HEAD
        CustomerAdress GetCustomerAddress(int addressId);
=======
        CustomerAdress GetCustomerAddress(string email);
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a
    }
}
