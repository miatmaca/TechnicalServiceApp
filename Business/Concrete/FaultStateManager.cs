using Business.Abstract;
using Business.Constans;
using Core.Asbect.Autofac.Caching;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FaultStateManager : IFaultStateService
    {
        IFaultStateDal _faultStateDal;

        public FaultStateManager(IFaultStateDal _faultStateDal)
        {
            this._faultStateDal = _faultStateDal;
        }
        [CacheRemoveAspect("IProcessControlService.Get")]
        public IResult Add(FaultState faultState)
        {
            faultState.CreatedDate = DateTime.Now;
            
            _faultStateDal.Add(faultState);
            return new SuccessResult(Messages.ProcessAdded);
        }
        [CacheRemoveAspect("IProcessControlService.Get")]
        public IResult Delete(FaultState faultState)
        {
            faultState.ModifiedDate = DateTime.Now;
            faultState.Status = 0;
            _faultStateDal.Update(faultState);
            return new SuccessResult(Messages.ProcessDelete);
        }
        [CacheAspect]
        public IDataResult<List<FaultState>> GetAll()
        {
            return new SuccessDataResult<List<FaultState>>(_faultStateDal.GetAll());
        }
        [CacheRemoveAspect("IProcessControlService.Get")]
        public IResult Update(FaultState faultState)
        {
            faultState.ModifiedDate = DateTime.Now;
            _faultStateDal.Update(faultState);
            return new SuccessResult(Messages.ProcessUpdate);
        }
    }
}
