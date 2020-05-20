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
        private readonly ICustomerRL irepo;
        public ImpCustomerManager(ICustomerRL irepo)
        {
            this.irepo = irepo;
        }
        public Task<int> AddCustomerAddress(CustomerAdressCL address)
        {
            return this.irepo.AddCustomerAddress(address);
        }
        public CustomerAdressCL GetCustomerAddress(string email)
        {
            return this.irepo.GetCustomerAddress(email);

        }
    }
}
