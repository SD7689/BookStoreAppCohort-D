using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBussinessLayer.LoginManager;
using Microsoft.AspNetCore.Mvc;
using BookStoreCommonLayer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManagerBL manager;

        public LoginController(ILoginManagerBL manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        public IActionResult LoginUser(User user)
        {
            var result=this.manager.LoginBL(user);
            if (result == true) {
                return this.Ok(user.Email);
            }
            else
            {
                var error = new JsonErrorModel { ErrorMessage = "Email or Password does not match" };
                return this.BadRequest(error);
            }

        }
        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var result =await this.manager.AddUserBL(user);
            if (result == 1)
            {
                return this.Ok(user);
            }
            return this.BadRequest();
        }
    }
}
