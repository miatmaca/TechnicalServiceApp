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
            var product = _productInfoService.GetProduct(productInfo.ProductId);
            product.StateControl = productInfo.StateControl;
           
            var result = _productInfoService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("makethepayment")]
        public IActionResult MakeThePayment(int productId)
        {
            var product = _productInfoService.GetProduct(productId);
            product.StateControl = 4;
            product.Status = 0;
            product.ModifiedBy = 1;
            var result = _productInfoService.Update(product);
            if (product!=null)
            {
                return Ok(product);
            }
            return BadRequest(product);

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
        [HttpGet("getnumberıfitemsinservice")]
        public IActionResult GetServiceProduct()//Serviste Durumunda Bulunan Eleman Sayısını Döner
        {
            var result = _productInfoService.NumberOfItemsInService();
            int son = result.Data.Count;
            if (result.Success)
            {
                return Ok(son);
            }
            return BadRequest(result);

        }
        [HttpGet("getnumberıfitemsinready")]
        public IActionResult NumberOfItemsInReady()//Teslime Hazır Eleman Sayısını Döner
        {
            var result = _productInfoService.NumberOfItemsInReady();
            int son = result.Data.Count;
            if (result.Success)
            {
                return Ok(son);
            }
            return BadRequest(result);

        }
        [HttpGet("getnumberıfitemsinaccepted")]
        public IActionResult NumberOfItemsInAccepted()//Teslim Alınan Eleman Sayısını Döner
        {
            var result = _productInfoService.NumberOfItemsInAccepted();
            int son = result.Data.Count;
            if (result.Success)
            {
                return Ok(son);
            }
            return BadRequest(result);

        }
        [HttpGet("getproductinfodto")]
        public IActionResult GetProductInfoDto()//Ürün Bilgilerinin Join Edilmiş Hali
        {
            var result = _productInfoService.GetProductInfoDto();           
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getservice")] //Servisde Bulunan Elamnları Listeler
        public IActionResult deneme(string stateName)
        {
            var result = _productInfoService.GetService(stateName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getallbyproductiddto")] //Servisde Bulunan Elamnları Listeler
        public IActionResult GetAllByProductIdDto(int productId)//Ürün Bilgilerinin Join Edilmiş Hali
        {
            var result = _productInfoService.GetAllByProductId(productId);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getallenddatadto")] 
        public IActionResult GetAllEndDataDto(int productId)//EndData Join
        {
            var result = _productInfoService.GetAllEndDataDto(productId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
