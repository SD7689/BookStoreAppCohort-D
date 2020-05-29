using Model;
using Remotion.Linq.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> AddUser(UserCL user)
        {
            var status = UserValidation(user.Email, user.Password);
            if (status)
            {

                var results = context.Users.Where(x => x.Email == user.Email);
                if (results.Count() == 0)
                {
                    var plainText = user.Password;
                    var encryptedData = Encrypt(plainText, "fg");
                    user.Password = encryptedData;
                    context.Users.Add(user);
                    var data = context.SaveChangesAsync();
                    return data;
                }
                else throw new NotImplementedException(" User is already registered");
            }
            else throw new NotImplementedException("Email or Password is not in valid formate");

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
            var encryptedText = Encrypt(cipher, "fg");
            user.Password = encryptedText;
            var result = context.Users.Where(id => id.Email == user.Email && id.Password == user.Password).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        ///  This is used for encrypting the input data.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
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
        /// <summary>
        ///   This is used for decrypting the encrypted input data.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
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
        /// <summary>
        /// This method is used for Password and Email validation
        /// </summary>
        /// <param name="email"></param>
        /// <param name="passowrd"></param>
        /// <returns></returns>
        public bool UserValidation(string email, string passowrd)
        {
            bool IsValid = false;
            Regex emailregex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex passwordRegexr = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            if (emailregex.IsMatch(email) && passwordRegexr.IsMatch(passowrd))
            {
                IsValid = true;
            }
            else
            {
                IsValid = false;
            }
            return IsValid;

        }
    }
}
