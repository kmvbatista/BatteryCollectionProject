using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.Extensions.Configuration;
using DataTypeObject;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.AspNetCore.Authorization;

namespace MVCPresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class TokenController:Controller
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] User request)
        {
            if (request.Email == "kennedy@gmail.com" && request.Password == "12345678")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Email)
                };
                //recebe uma instancia da classe SymetricSecurityKey
                //armazenando a chave de criptografia usada na criação do token
                var key = new SymmetricSecurityKey(
                              Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(

                    issuer: "kennedyBatteryProject",
                    audience: "BatteryCollectorUsers",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: creds
                );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("Credenciais Inválidas");
        }
    }
}
