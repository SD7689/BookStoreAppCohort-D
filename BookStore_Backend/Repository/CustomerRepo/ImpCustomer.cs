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

        public CustomerAdress GetCustomerAddress(int bookId)
        {
            return bookStoreDB.Address.Find(bookId);
        }
    }
}
