using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class ProcessControl:IEntity
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public int Price { get; set; }

    }
}
