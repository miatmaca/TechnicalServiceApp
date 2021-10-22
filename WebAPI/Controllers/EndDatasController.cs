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
    public class EndDatasController : ControllerBase
    {
        IEndDataService _endDataService;

        public EndDatasController(IEndDataService endDataService)
        {
            _endDataService = endDataService;
        }

        [HttpPost("add")]
        public IActionResult Add(EndData endData)
        {
            var result = _endDataService.Add(endData);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(EndData endData)
        {
            var result = _endDataService.Update(endData);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(EndData endData)
        {
            var result = _endDataService.Delete(endData);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _endDataService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getcommondto")]
        public IActionResult GetCommonDto()
        {
            var result = _endDataService.GetCommonDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }

}
