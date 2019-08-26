using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DataTypeObject;
using System.Security.Claims;

namespace MVCPresentationLayer.Controllers
{

    

    public class TokenController:Controller
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult RequestToken([FromBody] User request)
        {
            if(request.Email=="kennedy@gmail.com" && request.Password == "12345678")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Email)
                }
            }
        }
    }
}
