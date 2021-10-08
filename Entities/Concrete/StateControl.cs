using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class StateControl:IEntity
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}
