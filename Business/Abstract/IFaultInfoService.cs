using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IFaultInfoService
    {
        IResult Add(FaultInfo faultInfo);
        IResult Update(FaultInfo faultInfo);
        IResult Delete(FaultInfo faultInfo);
        IDataResult<List<FaultInfo>> GetAll();
    }
}
