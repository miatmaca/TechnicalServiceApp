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
    public class ProcessControlsController : ControllerBase
    {
        IProcessControlService _processControlService;

        public ProcessControlsController(IProcessControlService processControlService)
        {
            _processControlService = processControlService;
        }
        [HttpPost("add")]
        public IActionResult Add(ProcessControl processControl)
        {
            var result = _processControlService.Add(processControl);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(ProcessControl processControl)
        {
            var result = _processControlService.Update(processControl);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(ProcessControl processControl)
        {
            var result = _processControlService.Delete(processControl);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _processControlService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}

