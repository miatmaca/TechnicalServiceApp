using Core.DataAccess.Entities;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class ProductInfo: IEntity
    {
        public int ProductId { get; set; }
        public string BrandName { get; set; }
        public int OemName { get; set; }
        public string CategoryName { get; set; }
        public string SerialNo { get; set; }
        public string FaultName { get; set; }
        public int StateControl { get; set; }
        public int CustomerId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Status { get; set; }



    }
}
