using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataTypeObject;
using System.Transactions;

namespace MVCPresentationLayer.Controllers
{
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
                double totalUserDiscards = discardBLL.GetTotalUserDiscards(user);
                return new OkObjectResult(totalUserDiscards);
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
                if (discard == null)
                {
                    return BadRequest();
                }
                using (TransactionScope scope = new TransactionScope())
                {
                    discardBLL.Add(discard);
                    scope.Complete();
                    return Accepted();

                }
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{alldiscards}")]
        public IActionResult GetAllDataDiscards(User user)
        {
            try
            {
                IEnumerable<Discard> alldiscards = discardBLL.GetAllDataDiscards(user);
                return new OkObjectResult(alldiscards);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro no acesso ao banco de dados: " + ex);
            }
        }
    }
}
