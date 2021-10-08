using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IMaterialUsedService
    {
        IResult Add(MaterialUsed materialUsed);
        IResult Update(MaterialUsed materialUsed);
        IResult Delete(MaterialUsed materialUsed);
        IDataResult<List<MaterialUsed>> GetAll();
    }
}
