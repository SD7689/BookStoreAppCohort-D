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
        private readonly ILoginManager manager;

        public LoginController(ILoginManager manager)
        {
            this.manager = manager;
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult LoginUser(User user)
        {
            var result=this.manager.Login(user);
            if (result == true) {
                return this.Ok(user.Email);
            }
            else
            {
                return this.BadRequest("Login Failed");

            }

        }
        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var result =await this.manager.AddUser(user);
            if (result == 1)
            {
                return this.Ok(user);
            }
            return this.BadRequest();
        }
    }
}
