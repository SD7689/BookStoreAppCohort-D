using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            Encode(address.Password);
            return result;
        }

        /// <summary>
        /// Get Custmor detail by Email.
        /// </summary>
        /// <param name="Email_Id"></param>
        /// <returns>CustomerAdress.</returns>
        public CustomerAdress GetCustomerAddress(int CustomerId)
        {
            return bookStoreDB.Address.Find(CustomerId);
        }

        /// <summary>
        /// Custmor login Methods.
        /// </summary>
        /// <param name="Email_Id">Email_Id.</param>
        /// <param name="Password">Password.</param>
        /// <returns>Object.</returns>
        public IQueryable Login(string Email_Id, string Password)
        {
            var customerAdress = this.bookStoreDB.Address.Where(Address => Address.Email == Email_Id && Address.Password==Password);
            if (customerAdress != null)
                return customerAdress;
            return null;
        }

        private static void Encode(string password)
        {
            byte[] EncDataByte = new byte[password.Length];
            EncDataByte = System.Text.Encoding.UTF8.GetBytes(password);
            string EncrypData = Convert.ToBase64String(EncDataByte);
        }
    }
}
