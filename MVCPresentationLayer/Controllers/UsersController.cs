using Microsoft.AspNetCore.Mvc;
using DataTypeObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicalLayer;

namespace WebPresentationLayer.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserBLL userBLL;

        public UsersController(UserBLL _userBLL)
        {
            userBLL = _userBLL;
        }

        public IActionResult Login(string email, string password)
        { 
            User userFound= userBLL.Authenticate(email, password);
            if(userFound != null)
            {
                return new ObjectResult(userFound);
            }
            return NotFound();
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var userFound = userBLL.Find(id);
            if (userFound == null)
            {
                return NotFound();
            }
            return new ObjectResult(userFound);
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Create([FromBody] User _user)
        {
            if (_user == null)
            {
                return BadRequest();
            }
            try
            {
                userBLL.Add(_user);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetUser", new { id = _user.Id }, _user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            User userFound = userBLL.Find(id);
            if (userFound == null)
            {
                return NotFound();
            }
            try
            {
                userBLL.Update(user);
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
            var user = userBLL.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                userBLL.Remove(id);
            }
            catch(Exception)
            {
                return BadRequest();
            }

            return new NoContentResult();
        }
    }
}
