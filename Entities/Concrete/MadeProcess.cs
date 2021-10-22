using Core.DataAccess.Entities;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MadeProces: EntitiesBase
    {
        public int ProductId { get; set; }
        public string FaultName { get; set; }
        public int StateControl { get; set; }
        public int MadeProcess { get; set;}
        public  string StateNote { get; set; }



    }
}
