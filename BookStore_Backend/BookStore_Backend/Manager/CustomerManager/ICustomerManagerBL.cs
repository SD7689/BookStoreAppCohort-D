using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBussinessLayer.CustomerManager
{
   public interface ICustomerManagerBL
    {
        Task<int> AddCustomerAddressBL(CustomerAdress address);
        CustomerAdress GetCustomerAddressBL(string email);
    }
}
