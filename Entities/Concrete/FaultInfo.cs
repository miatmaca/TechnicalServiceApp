using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
  public  class FaultInfo:IEntity
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public string ReportedFault { get; set; }
        public int ServiceStateId { get; set; }
        public string Detection { get; set; }
        public string Offer { get; set; }
        public DateTime GetDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
