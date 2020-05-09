using Model;
using Repository.CustomerRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.CustomerManager
{
    public class ImpCustomerManager : ICustomerManager
    {
        private readonly ICustomer irepo;
        public ImpCustomerManager(ICustomer irepo)
        {
            this.irepo = irepo;
        }
        public Task<int> AddCustomerAddress(CustomerAdress address)
        {
            return this.irepo.AddCustomerAddress(address);
        }

        public CustomerAdress GetCustomerAddress(int addressId)
        {
            return this.irepo.GetCustomerAddress(addressId);
        }
    }
}
