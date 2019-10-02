using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataTypeObject;

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

        [HttpPost]
        public IActionResult Create([FromBody] Discard discard)//indica que o usuário vem pelo body da requisição
        {
            try
            {
                if (discard == null)
                {
                    return BadRequest();
                }
                discardBLL.Add(discard);
                return Accepted();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("all")]
        public IActionResult GetAllDataDiscards([FromBody]User user)
        {
            try
            {
                ChartData alldiscards = discardBLL.GetChartsData(user);
                GeneralData generalData = discardBLL.GetGeneralData(user);
                var materialsDiscarded = discardBLL.GetPieChartData(user.Id);
                var result = new { alldiscards, generalData, materialsDiscarded };
                return Json(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro no acesso ao banco de dados: " + ex);
            }
        }

        [HttpPost("general")]
        public IActionResult GetGeneralData([FromBody]User user)
        {
            try
            {
                GeneralData generalData = discardBLL.GetGeneralData(user);
                return new OkObjectResult(generalData);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro no acesso ao banco de dados: " + ex);
            }
        }
    }
}
