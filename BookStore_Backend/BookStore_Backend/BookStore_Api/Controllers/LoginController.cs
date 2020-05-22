using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBussinessLayer.LoginManager;
using Microsoft.AspNetCore.Mvc;
using BookStoreCommonLayer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManagerBL manager;
        private readonly IConfiguration _configruation;

        public LoginController(ILoginManagerBL manager, IConfiguration configruation)
        {
            this.manager = manager;
            this._configruation = configruation;
        }
        [HttpPost]
        public IActionResult LoginUser(User user)
        {
            try
            {
                var result = this.manager.LoginBL(user);
                if (result == true)
                {
                    return this.Ok(GenerateJSONWebToken(user));
                }
                else
                {
                    var error = new JsonErrorModel { ErrorMessage = "Email or Password does not match" };
                    return this.BadRequest(error);
                }
            }
            catch (Exception)
            {

                var error = new JsonErrorModel { ErrorMessage = "No_Such_User_Exist" };
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
        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configruation["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configruation["Jwt:Issuer"],
                _configruation["Jwt:Issuer"],
                 null,
                 expires: DateTime.Now.AddMinutes(120),
                 signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
