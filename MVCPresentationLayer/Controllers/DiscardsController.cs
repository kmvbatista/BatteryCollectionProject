using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataTypeObject;

namespace MVCPresentationLayer.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscardsController : Controller
    {
        
            private readonly IDISCARDCRUD discardBLL;

            public DiscardsController(IDISCARDCRUD _discardBLL)
            {
            this.discardBLL = _discardBLL;
            }

            // GET: api/Users/5
            [HttpGet("{totalnumber}")]
            public IActionResult GetAll(User user)
            {
                try
                {
                    
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            // POST: api/Users


            [HttpPost]
            public IActionResult Create([FromBody] Discard discard)//indica que o usuário vem pelo body da requisição
            {
                if (false)
                {
                    return BadRequest();
                }
                userPointsBLL.Add(userPoints);
                return Accepted();
            }

            [HttpGet("{allpoints}")]
            public IActionResult GetAllDataPoints(Discard discard)
            {
                try
                {
                    IEnumerable<UserPoints> allUserPoints = userPointsBLL.GetAllDataPoints(user);
                    return new OkObjectResult(allUserPoints);
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro no acesso ao banco de dados: " + ex);
                }
            }

            // PUT: api/Users/5
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody]  Discard discard)
            {
                if (userPoints == null || userPoints.Id != id)
                {
                    return BadRequest();
                }

                Discard discardfound  = userPointsBLL.Find(id);
                if (userPointsFound == null)
                {
                    return NotFound();
                }
                try
                {
                    userPointsBLL.Update(userPointsFound);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                return new NoContentResult();
            }
        }
}
