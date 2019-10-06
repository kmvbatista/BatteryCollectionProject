
using Microsoft.AspNetCore.Mvc;
using DataTypeObject;
using DataTypeObject.Interfaces;

namespace MVCPresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureHintController : Controller
    {
        private readonly IFEATURE bll;
        public FeatureHintController(IFEATURE _featureBLL)
        {
            bll = _featureBLL;
        }
        [HttpPost]
        public IActionResult SendEmail([FromBody] FeatureHint feature)
        {
            try
            {
                bll.SendEmail(feature);
                return Accepted();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}