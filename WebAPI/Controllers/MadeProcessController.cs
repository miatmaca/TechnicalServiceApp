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
    public class MadeProcessController : ControllerBase
    {
        IMadeProcessService _madeProcessService;

        public MadeProcessController(IMadeProcessService madeProcessService)
        {
            _madeProcessService = madeProcessService;
        }

        [HttpPost("add")]
        public IActionResult Add(MadeProces madeProces)
        {
            madeProces.CreatedDate = DateTime.Now;
            var result = _madeProcessService.Add(madeProces);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(MadeProces madeProces)
        {
            var result = _madeProcessService.Update(madeProces);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(MadeProces madeProces)
        {
            var result = _madeProcessService.Delete(madeProces);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _madeProcessService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getallDto")]
        public IActionResult GetAllDto(int productId)
        {
           
            var result = _madeProcessService.GetMadeProcessDto(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
