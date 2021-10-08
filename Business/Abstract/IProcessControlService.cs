using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProcessControlService
    {
        IResult Add(ProcessControl processControl);
        IResult Update(ProcessControl processControl);
        IResult Delete(ProcessControl processControl);
        IDataResult<List<ProcessControl>> GetAll();
    }
}
