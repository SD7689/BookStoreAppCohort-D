using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable GetCustomerAddressRL(string email)
        {
            var result = bookStoreDB.Address.Where(emailId => emailId.Email == email);
            return result;
        }
    }
}
