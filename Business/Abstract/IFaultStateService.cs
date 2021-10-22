using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IFaultStateService
    {
        IResult Add(FaultState faultState);
        IResult Update(FaultState faultState);
        IResult Delete(FaultState faultState);
        IDataResult<List<FaultState>> GetAll();
    }
}
