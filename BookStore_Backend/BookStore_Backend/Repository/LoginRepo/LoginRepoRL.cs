using Microsoft.OpenApi.Writers;
using Model;
using System;
using System.Collections.Generic;
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
            var plainP = user.Password;
            var encryptedData = EncryptPassword(plainP);

            user.Password = encryptedData;
            context.Users.Add(user);
            var result = context.SaveChangesAsync();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string EncryptPassword(string plainPassword)
        {
            byte[] data;
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                data = md5.ComputeHash(utf8.GetBytes(plainPassword));
                return Convert.ToBase64String(data);
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

            var result = context.Users.Where(id => id.Email == user.Email && id.Password == user.Password).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }
       
       
    }
}
