using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Category: EntitiesBase
    {
        public string CategoryName { get; set; }
        public int OemId { get; set; }
    }
}
