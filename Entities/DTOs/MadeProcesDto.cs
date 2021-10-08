using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MadeProcesDto:IEntity
    {
        public int ProductId { get; set; } 
        public string ProductName { get; set; } 
        public string EmployeeName { get; set; }
        public string ProcessName { get; set; }
        public int Price { get; set; }
        public string State { get; set; }
       
        public string Description { get; set; }
       


    }
}
