using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.CustomerRepo
{
    public class CustomerImpRL : ICustomerRL
    {
        private readonly BookStoreDBContext bookStoreDB;

        public CustomerImpRL(BookStoreDBContext bookStoreDB)
        {
            this.bookStoreDB = bookStoreDB;
        }

        public Task<int> AddCustomerAddressRL(CustomerAdress address)
        {
            bookStoreDB.Address.Add(address);
            var result = bookStoreDB.SaveChangesAsync();
            return result;
        }

        public CustomerAdress GetCustomerAddressRL(string email)
        {
            return bookStoreDB.Address.Find(email);
        }
    }
}
