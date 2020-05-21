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

            var result = context.Users.Where(id => id.Email == user.Email && id.Password == user.Password).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
