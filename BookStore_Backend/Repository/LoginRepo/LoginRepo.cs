using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.LoginRepo
{
    public class LoginRepo : ILoginRepo
    {
        private readonly BookStoreDBContext context;

        public LoginRepo(BookStoreDBContext context)
        {
            this.context = context;
        }

        public Task<int> AddUser(User user)
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
        public Object Login(string email, string password)
        {
            try
            {
                var result = context.Users.Where(id => id.Email == email && id.Password == password).FirstOrDefault();
                if (result == null)
                    throw new Exception("Email or password is not correct");
                return true;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
