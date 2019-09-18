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
    public class MaterialsController : Controller
    {
        private readonly IMATERIALCRUD materialBLL;
        public MaterialsController(IMATERIALCRUD materialBLL)
        {
            this.materialBLL = materialBLL;
        }
        [HttpPost]
        public IActionResult Add([FromBody] Material material)
        {
            try
            {
                materialBLL.AddAsync(material);
                return Accepted();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Remove(int Id)
        {
            try
            {
                materialBLL.Remove(Id);
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
                return new OkObjectResult(materialBLL.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody] Material material)
        {
            try
            {
                materialBLL.Update(material);
                return Accepted();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}