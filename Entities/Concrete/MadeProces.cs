using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MadeProces:IEntity
    {
        public int ProductId { get; set; }
        public int  StateId { get; set; }
        public int ProcessId { get; set; }
        public int EmployeeId { get; set; }
        public string Description { get; set; }
        public DateTime ReapirDate { get; set; }


    }
}
