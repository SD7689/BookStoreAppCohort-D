using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.CustomerRepo
{
   public interface ICustomerRL
    {
        Task<int> AddCustomerAddressRL(CustomerAdress address);
        IEnumerable<CustomerAdress> GetCustomerAddressRL(string email);
    }
}
