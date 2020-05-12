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

<<<<<<< HEAD
        public CustomerAdress GetCustomerAddress(int addressId)
        {
            return this.irepo.GetCustomerAddress(addressId);
=======
        public CustomerAdress GetCustomerAddress(string email)
        {
            return this.irepo.GetCustomerAddress(email);
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a
        }
    }
}
