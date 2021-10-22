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
    public class FaultStatesController : ControllerBase
    {
        IFaultStateService _faultStateService;

        public FaultStatesController(IFaultStateService faultStateService)
        {
            _faultStateService = faultStateService;
        }
        [HttpPost("add")]
        public IActionResult Add(FaultState processControl)
        {
            var result = _faultStateService.Add(processControl);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(FaultState processControl)
        {
            var result = _faultStateService.Update(processControl);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(FaultState processControl)
        {
            var result = _faultStateService.Delete(processControl);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _faultStateService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}

