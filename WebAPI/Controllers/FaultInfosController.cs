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
    public class FaultInfosController : ControllerBase
    {
        IFaultInfoService _faultInfoService;

        public FaultInfosController(IFaultInfoService faultInfoService)
        {
            _faultInfoService = faultInfoService;
        }

        [HttpPost("add")]
        public IActionResult Add(FaultInfo faultInfo)
        {
            var result = _faultInfoService.Add(faultInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(FaultInfo faultInfo)
        {
            var result = _faultInfoService.Update(faultInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(FaultInfo faultInfo)
        {
            var result = _faultInfoService.Delete(faultInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _faultInfoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
