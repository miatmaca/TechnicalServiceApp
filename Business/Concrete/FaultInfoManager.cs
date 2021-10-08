using Business.Abstract;
using Business.Constans;
using Business.Validation.FluentValidation;
using Core.Asbect.Autofac.Caching;
using Core.Asbect.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FaultInfoManager : IFaultInfoService
    {
        IFaultInfoDal _faultInfoDal;

        public FaultInfoManager(IFaultInfoDal faultInfoDal)
        {
            _faultInfoDal = faultInfoDal;
        }
        [ValidationAspect(typeof(FaultInfoValidator))]
        [CacheRemoveAspect("IFaultInfoService.Get")]//Doğrulama +
        public IResult Add(FaultInfo faultInfo)
        {
            
            _faultInfoDal.Add(faultInfo);
            return new SuccessResult(Messages.FaultInfoAdded);
        }
        [CacheRemoveAspect("IFaultInfoService.Get")]
        public IResult Delete(FaultInfo faultInfo)
        {
            _faultInfoDal.Delete(faultInfo);
            return new SuccessResult(Messages.FaultInfoDelete);
        }
        [CacheAspect]
        public IDataResult<List<FaultInfo>> GetAll()
        {
            return new SuccessDataResult<List<FaultInfo>>(_faultInfoDal.GetAll());
        }

        [CacheRemoveAspect("IFaultInfoService.Get")]
        public IResult Update(FaultInfo faultInfo)
        {
            _faultInfoDal.Update(faultInfo);
            return new SuccessResult(Messages.FaultInfoUpdate);
        }
    }
}
