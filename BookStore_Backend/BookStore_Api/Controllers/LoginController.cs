using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Manager.LoginManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using Model;

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
        [Route("Login")]
        
        [HttpPost]
        public IActionResult LoginUser(UserCL user)
        {
            var result = this.manager.Login(user);
            if (result == true)
            {
                return this.Ok(user.Email);
            }
            else
            {
                return this.BadRequest(new  JsonResult("Invalid UserName or Password"));

            }

        }
        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserCL user)
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
