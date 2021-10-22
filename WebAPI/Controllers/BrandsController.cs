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
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {   
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            var getbrand = _brandService.GetBrand(brand.BrandName);
            getbrand.BrandName = brand.BrandName;
            getbrand.Status = brand.Status;
            getbrand.ModifiedBy = brand.ModifiedBy;
            var result = _brandService.Update(getbrand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getallbystatusone")]
        public IActionResult GetAllByStatusOne()
        {
            var result = _brandService.GetAllByStatusOne();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}

