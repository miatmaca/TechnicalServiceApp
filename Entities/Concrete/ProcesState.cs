using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProcesState: EntitiesBase
    {
        public string ProcessName { get; set; }
        public int Price { get; set; }
    }
}
