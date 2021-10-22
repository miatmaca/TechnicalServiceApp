using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProcesStateService
    {
        IResult Add(ProcesState procesState);
        IResult Update(ProcesState procesState);
        IResult Delete(ProcesState procesState);
        IDataResult<List<ProcesState>> GetAll();
    }
}
