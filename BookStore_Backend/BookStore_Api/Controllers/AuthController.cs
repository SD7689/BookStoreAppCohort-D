using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Token")]
        public IActionResult GetToken()  
        {
            // Security Key
            string securitykey = "This_is_our_super_Long_security_key_for_validation";

            //Symmetric Security kry
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));

            //Signing Credentials
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha384Signature);

            //claim
            var claims = new[] {
             new Claim(ClaimTypes.Role, "Administrator"),
             new Claim("Our_Custom_claim", "Our Custom value"),
            };

            //Create token
            var token = new JwtSecurityToken(
                issuer: "smesh.in",
                audience: "reader",
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: signingCredentials,
                claims: claims
                );

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}