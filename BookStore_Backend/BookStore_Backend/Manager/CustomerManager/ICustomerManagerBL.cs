using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBussinessLayer.CustomerManager
{
   public interface ICustomerManagerBL
    {
        Task<int> AddCustomerAddressBL(CustomerAdress address);
        IQueryable GetCustomerAddressBL(string email);
    }
}
