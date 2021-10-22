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
    public class OemsController : ControllerBase
    {
        IOemService _oemsService;

        public OemsController(IOemService oemsService)
        {
            _oemsService = oemsService;
        }

        [HttpPost("add")]
        public IActionResult Add(Oem oem)
        {
            var result = _oemsService.Add(oem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(Oem oem)
        {
            var getOem= _oemsService.GetOem(oem.OemName);
            getOem.OemName = oem.OemName;
            getOem.Status = oem.Status;
            getOem.ModifiedBy = oem.ModifiedBy;
            var result = _oemsService.Update(getOem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(Oem oem)
        {
            var result = _oemsService.Delete(oem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _oemsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getallbystatusone")]
        public IActionResult GetAllByStatusOne()
        {
            var result = _oemsService.GetAllByStatusOne();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}

