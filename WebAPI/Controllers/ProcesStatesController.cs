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
    public class ProcesStatesController : ControllerBase
    {
        IProcesStateService _procesStateService;

        public ProcesStatesController(IProcesStateService procesStateService)
        {
            _procesStateService = procesStateService;
        }

        [HttpPost("add")]
        public IActionResult Add(ProcesState procesState)
        {
            var result = _procesStateService.Add(procesState);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(ProcesState procesState)
        {
            var result = _procesStateService.Update(procesState);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(ProcesState procesState)
        {
            var result = _procesStateService.Delete(procesState);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _procesStateService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
