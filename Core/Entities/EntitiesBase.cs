using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
   public class EntitiesBase:IEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Status { get; set; }

       
    }
}
