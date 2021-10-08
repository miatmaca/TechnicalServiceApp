using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class ProductInfo:IEntity
    {
        public int ProductId { get; set; }
        public string SerialNo { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

    }
}
