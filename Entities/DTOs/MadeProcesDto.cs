using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MadeProcesDto:IEntity
    {
        public int ProductId { get; set; } 
        public string MadeProcess { get; set; } 
        public string FaultName { get; set; }
        public string StateControl { get; set; }
      //  public string ProcessStatus { get; set; }
        public string StateNote { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Price { get; set; }
        public string BrandName { get; set; }
        public string OemName { get; set; }
        public string CategoryName { get; set; }
        public string SerialNo { get; set; }
        public int TotalPrice { get; set; }
        public string Customer { get; set; }
        public string Gsm { get; set; }

    }
}
