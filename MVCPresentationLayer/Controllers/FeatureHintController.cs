
using Microsoft.AspNetCore.Mvc;
using DataTypeObject;
using DataTypeObject.Interfaces;

namespace MVCPresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureHintController : Controller
    {
        private readonly IFEATURE featureBLL;
        public FeatureHintController(IFEATURE _featureBLL)
        {
            this.featureBLL = _featureBLL;
        }
        [HttpPost]
        public IActionResult SendEmail([FromBody] FeatureHint feature)
        {
            try
            {
                featureBLL.SendEmail(feature);
                return Accepted();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}