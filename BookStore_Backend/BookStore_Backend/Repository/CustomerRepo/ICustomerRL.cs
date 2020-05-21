using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.CustomerRepo
{
   public interface ICustomerRL
    {
        Task<int> AddCustomerAddressRL(CustomerAdress address);
        CustomerAdress GetCustomerAddressRL(string email);
    }
}
