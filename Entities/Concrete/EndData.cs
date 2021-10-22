using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
  public  class EndData:EntitiesBase
    {
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int MadeProcess { get; set; }
        public int CustomerId { get; set; }
        
    }
}
