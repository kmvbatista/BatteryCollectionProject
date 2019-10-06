using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataTypeObject;
using BusinessLogicalLayer;
using Microsoft.AspNetCore.Authorization;

namespace MVCPresentationLayer.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : Controller
    {
        private readonly IPLACECRUD placeBLL;
        public PlacesController(IPLACECRUD placeBLL)
        {
            this.placeBLL = placeBLL;
        }

        private void VerifyPlace(Place place)
        {
            if(place.Name==null)
            {
                throw new Exception();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return new OkObjectResult(placeBLL.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}