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

        /// <summary>
        /// Add the Custmor Address.
        /// </summary>
        /// <param name="address">address</param>
        /// <returns>int.</returns>
        public Task<int> AddCustomerAddress(CustomerAdress address)
        {
            bookStoreDB.Address.Add(address);
            var result = bookStoreDB.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Get Custmor detail by Email.
        /// </summary>
        /// <param name="Email_Id"></param>
        /// <returns>CustomerAdress.</returns>
        public CustomerAdress GetCustomerAddress(string Email_Id)
        {
            return bookStoreDB.Address.Find(Email_Id);
        }

        /// <summary>
        /// Custmor login Methods.
        /// </summary>
        /// <param name="Email_Id">Email_Id.</param>
        /// <param name="Password">Password.</param>
        /// <returns>Object.</returns>
        public CustomerAdress Login(string Email_Id, string Password)
        {
            CustomerAdress customerAdress = bookStoreDB.Address.Find(Email_Id);
            if (customerAdress.Password == Password || customerAdress != null)
                return customerAdress;
            return null;
        }
    }
}
