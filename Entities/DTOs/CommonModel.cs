using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CommonModel:IDto
    {
        /// <summary>
       
        public int ProductId { get; set; }
        public string SerialNo { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string AddressProduct { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string AddressCustomer { get; set; }
        public string GSM { get; set; }
        /// <summary>
        
        public int EmployeeId { get; set; }
        public string ReportedFault { get; set; }
        public int ServiceStateId { get; set; }
        public string Detection { get; set; }
        public string Offer { get; set; }
        public DateTime GetDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
