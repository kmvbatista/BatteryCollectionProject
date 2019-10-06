using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataTypeObject;
using Microsoft.AspNetCore.Authorization;

namespace MVCPresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : Controller
    {
        private readonly IMATERIALCRUD materialBLL;
        public MaterialsController(IMATERIALCRUD materialBLL)
        {
            this.materialBLL = materialBLL;
        }
   
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return new OkObjectResult(materialBLL.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}