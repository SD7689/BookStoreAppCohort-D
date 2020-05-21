using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.LoginRepo
{
    public class LoginRepoRL : ILoginRepoRL
    {
        private readonly BookStoreDBContext context;

        public LoginRepoRL(BookStoreDBContext context)
        {
            this.context = context;
        }

        public Task<int> AddUserRL(User user)
        {
            var encodedPassword=base64Encode(user.Password);
            user.Password = encodedPassword;
            context.Users.Add(user);
            var result = context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Login for Customer with email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoginRL(User user)
        {
            var result = context.Users.Where(id => id.Email == user.Email).FirstOrDefault();
            var passwd = base64Decode(result.Password);
            if (user.Password==passwd)
            {
                return true;
            }
            return false;
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
