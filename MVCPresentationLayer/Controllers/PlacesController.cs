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
        [HttpPost]
        public IActionResult Add([FromBody] Place place)
        {
            try
            {
                VerifyPlace(place);
                 placeBLL.Add(place);
                return Accepted();
            }
            catch
            {
                return BadRequest();
            }
        }

        private void VerifyPlace(Place place)
        {
            if(place.Name==null)
            {
                throw new Exception();
            }
        }

        [HttpDelete]
        public IActionResult Remove(int Id)
        {
            try
            {
                placeBLL.Remove(Id);
                return Accepted();

            }
            catch
            {
                return BadRequest();
            }
        }
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
        [HttpPut]
        public IActionResult Update([FromBody] Place place)
        {
            try
            {
                placeBLL.Update(place);
                return Accepted();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}