using Microsoft.OpenApi.Writers;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.LoginRepo
{
    public class LoginRepoRL : ILoginRepoRL
    {
        private readonly BookStoreDBContext context;

        public LoginRepoRL(BookStoreDBContext context)
        {
            this.context = context;
        }

        //public Task<int> AddUser(UserCL user)
        //{
        //    context.Users.Add(user);
        //    var result = context.SaveChangesAsync();
        //    return result;
        //}

        public Task<int> AddUser(UserCL user)
        {
            var plainPassword = user.Password;
            var encryptedData = EncodePasswordToBase64(plainPassword);
            user.Password = encryptedData;

            //var encodedValue = user.Password;
            //var decData = DecodeFrom64(encodedValue);

            //user.Password = decData;

            context.Users.Add(user);
            var result = context.SaveChangesAsync();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        //public string EncryptPassword(string plainPassword)
        //{
        //    byte[] data;
        //    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        //    {
        //        UTF8Encoding utf8 = new UTF8Encoding();
        //        data = md5.ComputeHash(utf8.GetBytes(plainPassword));
        //        var encodedValue= Convert.ToBase64String(data);
        //        return encodedValue;
        //    }

        //}
        public static string EncodePasswordToBase64(string password)
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
        public string DecodeFrom64(string encodedValue)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedValue);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string decresult = new String(decoded_char);
            return decresult;
        }



        /// <summary>
        /// Login for Customer with email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(UserCL user)
        {
           

            var result = context.Users.Where(id => id.Email == user.Email && id.Password == user.Password).FirstOrDefault();
            
            if (result == null)
            {
                return false;
            }
            return true;
        }
       
       
    }
}
