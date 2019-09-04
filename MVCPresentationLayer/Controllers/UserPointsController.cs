using Microsoft.AspNetCore.Mvc;
using DataTypeObject;
using System;
using Microsoft.AspNetCore.Authorization;

namespace WebPresentationLayer.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class UserPointsController : ControllerBase
    {
        private readonly IUSERPOINTSCRUD userPointsBLL;

        public UserPointsController(IUSERPOINTSCRUD _userPointsBLL)
        {
            userPointsBLL = _userPointsBLL;
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
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var userFound = userPointsBLL.Find(id);
            if (userFound == null)
            {
                return NotFound();
            }
            return new ObjectResult(userFound);
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = userPointsBLL.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                userPointsBLL.Remove(id);
            }
            catch(Exception)
            {
                return BadRequest();
            }

            return new NoContentResult();
        }
    }
}
