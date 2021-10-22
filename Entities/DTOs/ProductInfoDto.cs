using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductInfoDto : IDto
    {


        public int ProductId { get; set; }
        public string brandName { get; set; }
        public string OemName { get; set; }
        public string Category { get; set; }
        public string SerialNo { get; set; }
        public string FaultName { get; set; }
        public string StateName { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserNameSurname { get; set; }
        public string  Gsm { get; set; }

        public int Status { get; set; }
        /// <summary>

    }
}
