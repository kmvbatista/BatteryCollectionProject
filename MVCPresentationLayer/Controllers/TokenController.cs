using Microsoft.AspNetCore.Mvc;
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
    [Authorize()]
    [Route("api/[controller]")]
    public class TokenController:Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUSERCRUD _userBLL;


        public TokenController(IConfiguration configuration, IUSERCRUD userBLL)
        {
            _configuration = configuration;
            _userBLL = userBLL;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] User request)
        {
            try
            {
                User user = _userBLL.Authenticate(request.Email, request.Password);
                //User user = new User(3, "gabriel", "gabriel.rcosta57@gmail.com");
                if (user != null) {
                    User userToSend = new User(user.Id, user.Name, user.Email);
                    var resultado = new
                    {
                        token = getToken(request),
                        userToSend 
                    };
                    return Json(resultado); 
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        private IActionResult getToken(User request)
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
            throw new Exception("Credenciais Inválidas");
        }
    }
}
