using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
    public class CommonsController : ControllerBase
    {
        IProductInfoService _productInfoService;
        ICustomerService _customerService;
        IFaultInfoService _faultInfoService;


        public CommonsController(IProductInfoService productInfoService,
                                 ICustomerService customerService,
                                 IFaultInfoService faultInfoService)
        {
            _productInfoService = productInfoService;
            _customerService = customerService;
            _faultInfoService = faultInfoService;
        }

        [HttpPost("add")]
        public IActionResult Add(CommonModel commonModel)
        {
            var productInfo = new ProductInfo()
            {
                Address = commonModel.AddressProduct,
                SerialNo = commonModel.SerialNo,
                Brand = commonModel.Brand,
                Description = commonModel.Description,
                Model = commonModel.Model,
                ProductType = commonModel.ProductType
            };

            var result = _productInfoService.Add(productInfo);
            int productId = productInfo.ProductId;
            var customerInfo = new Customer()
            {
                Address = commonModel.AddressCustomer,
                CustomerName = commonModel.CustomerName,
                GSM = commonModel.GSM
            };
            result = _customerService.Add(customerInfo);
            int customerId = customerInfo.CustomerId;
            var faultInfo = new FaultInfo()
            {
                ProductId=productId,
                CustomerId=customerId,
                ServiceStateId=commonModel.ServiceStateId,
                DeliveryDate=commonModel.DeliveryDate,
                Detection=commonModel.Detection,
                EmployeeId=commonModel.EmployeeId,
                GetDate=commonModel.GetDate,
                Offer=commonModel.Offer,
                ReportedFault=commonModel.ReportedFault
            };
            result = _faultInfoService.Add(faultInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
