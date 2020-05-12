using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CustomerRepo
{
    public class ImpCustomer : ICustomer
    {
        private readonly BookStoreDBContext bookStoreDB;

        public ImpCustomer(BookStoreDBContext bookStoreDB)
        {
            this.bookStoreDB = bookStoreDB;
        }

        public Task<int> AddCustomerAddress(CustomerAdress address)
        {
            bookStoreDB.Address.Add(address);
            var result = bookStoreDB.SaveChangesAsync();
            return result;
        }

<<<<<<< HEAD
        public CustomerAdress GetCustomerAddress(int addressId)
        {
            return bookStoreDB.Address.Find(addressId);
=======
        public CustomerAdress GetCustomerAddress(string email)
        {
            return bookStoreDB.Address.Find(email);
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a
        }
    }
}
