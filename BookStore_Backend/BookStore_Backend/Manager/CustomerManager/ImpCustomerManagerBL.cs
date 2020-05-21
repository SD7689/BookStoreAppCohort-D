using BookStoreCommonLayer;
using BookStoreRepositoryLayer.CustomerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBussinessLayer.CustomerManager
{
    public class ImpCustomerManagerBL : ICustomerManagerBL
    {
        private readonly ICustomerRL irepo;
        public ImpCustomerManagerBL(ICustomerRL irepo)
        {
            this.irepo = irepo;
        }
        public Task<int> AddCustomerAddressBL(CustomerAdress address)
        {
            return this.irepo.AddCustomerAddressRL(address);
        }

        public IQueryable GetCustomerAddressBL(string email)
        {
            return this.irepo.GetCustomerAddressRL(email);
        }
    }
}
