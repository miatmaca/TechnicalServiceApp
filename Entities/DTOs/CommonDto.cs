using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class CommonDto
    {  
        //Ürün Bilgileri
        public int ProductId { get; set; }
        public string BrandName { get; set; }
        public string OemName { get; set; }   
        public string CategoryName { get; set; }
        public string SerialNo { get; set; }
        public string FaultName { get; set; }
        public string StateName { get; set; }
        public string MadeProcess { get; set; }
        public string StateNote { get; set; }            
        public int Price { get; set; }      

        //Müşteri Bilgileri
        public int CustomerId { get; set; }  
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGsm { get; set; }

        //Personel Bilgileri
        public int CreatedBy { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserGsm { get; set; }


        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Status { get; set; }
        

      
    }
}
