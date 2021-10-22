using Business.Abstract;
using Business.Constans;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProcesStateManager : IProcesStateService
    {
        IProcesStateDal _procesStateDal;

        public ProcesStateManager(IProcesStateDal procesStateDal)
        {
            _procesStateDal = procesStateDal;
        }

        public IResult Add(ProcesState procesState)
        {
            _procesStateDal.Add(procesState);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(ProcesState procesState)
        {
            _procesStateDal.Delete(procesState);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<ProcesState>> GetAll()
        {
            return new SuccessDataResult<List<ProcesState>>(_procesStateDal.GetAll());
        }

        public IResult Update(ProcesState procesState)
        {
            _procesStateDal.Update(procesState);
            return new SuccessResult(Messages.Update);
        }
    }
}
