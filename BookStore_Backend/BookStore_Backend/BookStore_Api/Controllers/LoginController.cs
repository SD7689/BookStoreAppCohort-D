using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.LoginManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManagerBL manager;
        /// <summary>
        /// Create Config reference variable to configure with appsetting.json file and startup.cs class
        /// </summary>
        private readonly IConfiguration _config;

        public LoginController(ILoginManagerBL manager, IConfiguration _config)
        {
            this.manager = manager;
            this._config = _config;
        }
       
        [Route("Login")]
        [HttpPost]
        public IActionResult LoginUser(UserCL user)
        {
            var result = this.manager.Login(user);
            if (result == true)
            {
                return this.Ok(GenerateJSONWebToken(user));
            }
            else
            {
                return this.BadRequest(new { error="Incorect Email and Pasword" }) ;

            }

        }
        [Route("AddUsers")]
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
        private string GenerateJSONWebToken(UserCL userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
