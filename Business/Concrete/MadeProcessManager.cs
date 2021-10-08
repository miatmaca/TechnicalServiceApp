using Business.Abstract;
using Business.Constans;
using Core.Asbect.Autofac.Caching;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MadeProcessManager : IMadeProcessService
    {
        IMadeProcessDal _madeprocessDal;

        public MadeProcessManager(IMadeProcessDal madeprocessDal)
        {
            _madeprocessDal = madeprocessDal;
        }
        [CacheRemoveAspect("IMadeProcessService.Get")]
        public IResult Add(MadeProces madeProces)
        {
            _madeprocessDal.Add(madeProces);
            return new SuccessResult(Messages.MadeProcessAdded);
        }
        [CacheRemoveAspect("IMadeProcessService.Get")]
        public IResult Delete(MadeProces madeProces)
        {
            _madeprocessDal.Delete(madeProces);
            return new SuccessResult(Messages.MadeProcessDelete);
        }

        public IDataResult<List<MadeProces>> GetAll()
        {
            return new SuccessDataResult<List<MadeProces>>(_madeprocessDal.GetAll());
        }

        public IDataResult<List<MadeProcesDto>> GetMadeProces(int productId)
        {
            return new SuccessDataResult<List<MadeProcesDto>>(_madeprocessDal.GetMadeProcess(productId));
        }
        [CacheRemoveAspect("IMadeProcessService.Get")]
        public IResult Update(MadeProces madeProces)
        {
            _madeprocessDal.Update(madeProces);
            return new SuccessResult(Messages.MadeProcessUpdate);
        }
    }
}
