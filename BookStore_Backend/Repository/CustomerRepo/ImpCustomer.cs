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
            var encodedPassword = base64Encode(address.Password);
            address.Password = encodedPassword;
            bookStoreDB.Address.Add(address);
            var result = bookStoreDB.SaveChangesAsync();
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
        public CustomerAdress Login(string Email_Id, string Password)
        {
            CustomerAdress customerAdress = this.bookStoreDB.Address.Where(Address => Address.Email == Email_Id && Password == base64Decode(Address.Password)).FirstOrDefault(); ;
            if (customerAdress != null)
                return customerAdress;
            return null;
        }

        public static string base64Encode(string password) // Encode    
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
    }
}
