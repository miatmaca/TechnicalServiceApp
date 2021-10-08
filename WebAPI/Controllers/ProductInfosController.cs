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
    public class ProductInfosController : ControllerBase
    {
        IProductInfoService _productInfoService;
        ICustomerService _customerService;


        public ProductInfosController(IProductInfoService productInfoService,
                                      ICustomerService customerService)
        {
            _productInfoService = productInfoService;
            _customerService = customerService;
        }

        [HttpPost("add")]
        public IActionResult Add(ProductInfo productInfo)
        {
            var result = _productInfoService.Add(productInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(ProductInfo productInfo)
        {
            var result = _productInfoService.Update(productInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(ProductInfo productInfo)
        {
            var result = _productInfoService.Delete(productInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productInfoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
