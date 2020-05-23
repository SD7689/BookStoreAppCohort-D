using Model;
using Remotion.Linq.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.LoginRepo
{
    public class LoginRL : ILoginRL
    {
        private readonly BookStoreDBContext context;

        public LoginRL(BookStoreDBContext context)
        {
            this.context = context;
        }

        public Task<int> AddUser(UserCL user)
        {
            var results = context.Users.Where(x => x.Email == user.Email);
            if (results==null)
            {
                var plainText = user.Password;
                var encryptedData = Encrypt(plainText, "fg");
                user.Password = encryptedData;
                context.Users.Add(user);
                var data = context.SaveChangesAsync();
                return data;
            }
            else
            {
                 throw new NotImplementedException (" User is already registered");
            }
           
        }

        /// <summary>
        /// Login for Customer with email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(UserCL user)
        {
            var cipher = user.Password;
            var encryptedText = Encrypt(cipher,"fg");
            user.Password = encryptedText;
            var result = context.Users.Where(id => id.Email == user.Email && id.Password == user.Password).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public string Encrypts(string plainText)
        {
            byte[] data;
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                data = md5.ComputeHash(utf8.GetBytes(plainText));
                return Convert.ToBase64String(data);
            }

        }

        public string Encrypt(string input, string key)
        {
            string strReturnVal = "";
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            tripleDES.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            strReturnVal = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            return strReturnVal;

        }
        public string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            tripleDES.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
           
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
