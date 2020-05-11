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

        public CustomerAdress GetCustomerAddress(string Email_Id)
        {
            return bookStoreDB.Address.Find(Email_Id);
        }

        public Object Login(string Email_Id, string Password)
        {
            CustomerAdress customerAdress=  bookStoreDB.Address.Find(Email_Id);
            if (customerAdress.Password == Password || customerAdress != null)
                return customerAdress;
            return "Please Enter the Valid Email_Id and Password ";
        }
    }
}
