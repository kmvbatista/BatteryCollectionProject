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
                return discardBLL.GetAll();
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
            try
            {
                if (discard != null)
                {
                    return BadRequest();
                }
                discardBLL.Add(discards);
                return Accepted();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{alldiscards}")]
        public IActionResult GetAllDataPoints(User user)
        {
            try
            {
                IEnumerable<Discard> alldiscards = discardBLL.getAllDiscards(user);
                return new OkObjectResult(alldiscards);
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
            if (discard == null || discard.Id != id)
            {
                return BadRequest();
            }

            Discard discardFound = discardBLL.Find(id);
            if (discardFound == null)
            {
                return NotFound();
            }
            try
            {
                discardBLL.Update(discardFound);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return new NoContentResult();
        }
    }
}
