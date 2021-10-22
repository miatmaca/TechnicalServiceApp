using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IOemService
    {
        IResult Add(Oem oem);
        IResult Update(Oem oem);
        IResult Delete(Oem oem);
        IDataResult<List<Oem>> GetAll(); 
         Oem GetOem(string oemName);
        IDataResult<List<Oem>> GetAllByStatusOne();
    }
}
