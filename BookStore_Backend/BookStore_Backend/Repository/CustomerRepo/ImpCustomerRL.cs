using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CustomerRepo
{
    public class ImpCustomerRL : ICustomerRL
    {
        private readonly BookStoreDBContext bookStoreDB;

        public ImpCustomerRL(BookStoreDBContext bookStoreDB)
        {
            this.bookStoreDB = bookStoreDB;
        }

        public Task<int> AddCustomerAddress(CustomerAdressCL address)
        {
            bookStoreDB.Address.Add(address);
            var result = bookStoreDB.SaveChangesAsync();
            return result;
        }

        public CustomerAdressCL GetCustomerAddress(string email)
        {
            return bookStoreDB.Address.Find(email);
        }
    }
}
