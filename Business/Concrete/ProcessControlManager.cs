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
    public class ProcessControlManager : IProcessControlService
    {
        IProcessControlDal _processControlDal;

        public ProcessControlManager(IProcessControlDal processControlDal)
        {
            _processControlDal = processControlDal;
        }
        [CacheRemoveAspect("IProcessControlService.Get")]
        public IResult Add(ProcessControl processControl)
        {
            _processControlDal.Add(processControl);
            return new SuccessResult(Messages.ProcessAdded);
        }
        [CacheRemoveAspect("IProcessControlService.Get")]
        public IResult Delete(ProcessControl processControl)
        {
            _processControlDal.Delete(processControl);
            return new SuccessResult(Messages.ProcessDelete);
        }
        [CacheAspect]
        public IDataResult<List<ProcessControl>> GetAll()
        {
            return new SuccessDataResult<List<ProcessControl>>(_processControlDal.GetAll());
        }
        [CacheRemoveAspect("IProcessControlService.Get")]
        public IResult Update(ProcessControl processControl)
        {
            _processControlDal.Update(processControl);
            return new SuccessResult(Messages.ProcessUpdate);
        }
    }
}
