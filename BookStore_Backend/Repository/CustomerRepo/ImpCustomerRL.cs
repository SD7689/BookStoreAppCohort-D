using Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<int> AddCustomerAddress(CustomerCL address)
        {
            bookStoreDB.Address.Add(address);
            var result = bookStoreDB.SaveChangesAsync();
            return result;
        }

        public CustomerCL GetCustomerAddress(string email)
        {

            return bookStoreDB.Address.Where(x => x.Email == email).FirstOrDefault();
        }
    }
}
