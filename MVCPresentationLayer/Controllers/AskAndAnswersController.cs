using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataTypeObject;

namespace MVCPresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AskAndAnswersController : Controller
    {
        private readonly IAsksAndAnswersCrud asksAndAnswersBll;
        public AskAndAnswersController(IAsksAndAnswersCrud _asksAndAnswersBll)
        {
            this.asksAndAnswersBll = _asksAndAnswersBll;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return new OkObjectResult(asksAndAnswersBll.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}