using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using CloudinaryDotNet.Actions;
using Manager.LoginManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Writers;
using Model;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore_Api.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManagerBL manager;
        private readonly IConfiguration configuration;
        public LoginController(ILoginManagerBL manager , IConfiguration configuration)
        {
            this.manager = manager;
            this.configuration = configuration;
        }   
        /// <summary>
        /// user login form
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [ActionName(" Login form")]
        [HttpPost]
        public ActionResult LoginUser(UserCL user)
        {
            var result = this.manager.Login(user);
            if (result == true)
            {
                var token = GenerateJSONWebToken(user);          
                return this.Ok(new {Token=token });
            }
            else
            {

                return this.BadRequest(new { error = "Invalid UserName or Password" });

            }

        }
        /// <summary>
        /// user registration form
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [ActionName(" User Registration")]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserCL user)
        {
            try
            {
                var result = await this.manager.AddUser(user);
                if (result == 1)
                {
                    return this.Ok(user);
                }
                return this.BadRequest(new { v = "error" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { error=e.Message});
            }
           
        }

        private string GenerateJSONWebToken(UserCL user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],configuration["Jwt:Issuer"],
                 null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
