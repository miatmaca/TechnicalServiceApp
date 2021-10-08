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
    public class MaterialUsedManager : IMaterialUsedService
    {
        IMaterialUsedDal _materialUsedDal;

        public MaterialUsedManager(IMaterialUsedDal materialUsedDal)
        {
            _materialUsedDal = materialUsedDal;
        }
        [CacheRemoveAspect("IMaterialService.Get")]
        public IResult Add(MaterialUsed materialUsed)
        {
            _materialUsedDal.Add(materialUsed);
            return new SuccessResult(Messages.MaterialUsedAdded);
        }
        [CacheRemoveAspect("IMaterialService.Get")]
        public IResult Delete(MaterialUsed materialUsed)
        {
            _materialUsedDal.Delete(materialUsed);
            return new SuccessResult(Messages.MaterialUsedDelete);
        }
        [CacheAspect]
        public IDataResult<List<MaterialUsed>> GetAll()
        {
            return new SuccessDataResult<List<MaterialUsed>>(_materialUsedDal.GetAll());
        }
        [CacheRemoveAspect("IMaterialService.Get")]
        public IResult Update(MaterialUsed materialUsed)
        {
            _materialUsedDal.Update(materialUsed);
            return new SuccessResult(Messages.MaterialUsedUpdate);
        }
    }
}
