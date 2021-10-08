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
    public class StateControlsController : ControllerBase
    {
        IStateControlService  _stateControlService;

        public StateControlsController(IStateControlService stateControlService)
        {
            _stateControlService = stateControlService;
        }

        [HttpPost("add")]
        public IActionResult Add(StateControl stateControl)
        {
            var result = _stateControlService.Add(stateControl);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(StateControl stateControl)
        {
            var result = _stateControlService.Update(stateControl);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(StateControl stateControl)
        {
            var result = _stateControlService.Delete(stateControl);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _stateControlService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
