using Model;
using Repository.CustomerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public CustomerAdress GetCustomerAddress(int CustomerId)
        {
            return this.irepo.GetCustomerAddress(CustomerId);
        }

        public IQueryable Login(string Email, string Password)
        {
            return this.irepo.Login(Email, Password);
        }

    }
}
