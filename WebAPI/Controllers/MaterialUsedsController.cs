using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialUsedsController : ControllerBase
    {
        IMaterialUsedService _materialUsedService;

        public MaterialUsedsController(IMaterialUsedService materialUsedService)
        {
            _materialUsedService = materialUsedService;
        }

        [HttpPost("add")]
        public IActionResult Add(MaterialUsed materialUsed)
        {
            var result = _materialUsedService.Add(materialUsed);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(MaterialUsed materialUsed)
        {
            var result = _materialUsedService.Update(materialUsed);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(MaterialUsed materialUsed)
        {
            var result = _materialUsedService.Delete(materialUsed);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _materialUsedService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
