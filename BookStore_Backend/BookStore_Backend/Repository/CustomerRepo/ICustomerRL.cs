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
        IQueryable GetCustomerAddressRL(string email);
    }
}
