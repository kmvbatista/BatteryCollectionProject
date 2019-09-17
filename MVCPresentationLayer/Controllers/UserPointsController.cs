using DataTypeObject;
using System;
using Microsoft.AspNetCore.Authorization;
using BusinessLogicalLayer;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace WebPresentationLayer.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class UserPointsController : ControllerBase
    {
        private readonly IUSERPOINTSCRUD userPointsBLL;
        private readonly IUSERCRUD _userBLL;

        public UserPointsController(IUSERPOINTSCRUD _userPointsBLL, IUSERCRUD userBLL)
        {
            userPointsBLL = _userPointsBLL;
            this._userBLL = userBLL;
        }

        /*
        [HttpPost]
        public IActionResult Login(string email, string password)
        { 
            User userFound= userPointsBLL.Authenticate(email, password);
            if(userFound != null)
            {
                return new ObjectResult(userFound);
            }
            return NotFound();
        }
        */

        // GET: api/Users/5
        [HttpGet("{totalnumber}")]
        public IActionResult GetTotalPoints(User user)
        {
            try
            {
                double userPointsFound = this.userPointsBLL.GetTotalPoints();
                return new OkObjectResult(userPointsFound);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Users
        

        [HttpPost]
        public IActionResult Create([FromBody] UserPoints userPoints)//indica que o usuário vem pelo body da requisição
        {
            if (userPoints == null)
            {
                return BadRequest();
            }
            userPointsBLL.Add(userPoints);
            return Accepted();
        }

        [HttpGet("{allpoints}")]
        public IActionResult GetAllDataPoints(User user)
        {
            try
            {
                IEnumerable<UserPoints> allUserPoints =  userPointsBLL.GetAllDataPoints(user);
                return new OkObjectResult(allUserPoints);
            }
            catch(Exception ex)
            {
                return BadRequest("Erro no acesso ao banco de dados: "+ ex);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserPoints userPoints)
        {
            if (userPoints == null || userPoints.Id != id)
            {
                return BadRequest();
            }

            UserPoints userPointsFound = userPointsBLL.Find(id);
            if (userPointsFound == null)
            {
                return NotFound();
            }
            try
            {
                userPointsBLL.Update(userPointsFound);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            return new NoContentResult();
        }

    }
}
