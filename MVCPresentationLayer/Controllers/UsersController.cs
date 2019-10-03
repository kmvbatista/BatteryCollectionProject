using Microsoft.AspNetCore.Mvc;
using DataTypeObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebPresentationLayer.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUSERCRUD userBLL;

        public UsersController(IUSERCRUD _userBLL)
        {
            userBLL = _userBLL;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return userBLL.GetAll();
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
        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create([FromBody] User user)//indica que o usuário vem pelo body da requisição
        {
            if (user == null)
            {
                return BadRequest();
            }
            user.Password= HashUtils.HashPassword(user.Password);
            userBLL.Add(user);
            //return CreatedAtRoute("GetUser", new { id = user.Id }, user);//cria uma URI que retorna o usuário recém-criado
            return Accepted();

        }
        [HttpGet("ranking")]
        public IActionResult GetRankingData()
        {
            var ranking = userBLL.GetRankingData();
            //return CreatedAtRoute("GetUser", new { id = user.Id }, user);//cria uma URI que retorna o usuário recém-criado
            return new JsonResult(ranking);

        }
        // PUT: api/Users/5
        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            User userFound = userBLL.Find(user.Id);
            if (userFound == null)
            {
                return NotFound();
            }
            try
            {
                User updatedUser= userBLL.Update(user);
                return new OkObjectResult(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
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
