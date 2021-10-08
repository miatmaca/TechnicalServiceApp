using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class MaterialUsed:IEntity
    {
        public int ProductId { get; set; }
        public int SeriNo { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

    }
}
