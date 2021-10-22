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
    public class StateControlManager : IStateControlService
    {
        IStateControlDal _stateControlDal;

        public StateControlManager(IStateControlDal stateControlDal)
        {
            _stateControlDal = stateControlDal;
        }
        [CacheRemoveAspect("IStateControlService.Get")]
        public IResult Add(StateControl stateControl)
        {
            stateControl.CreatedDate = DateTime.Now;
            _stateControlDal.Add(stateControl);
            return new SuccessResult(Messages.StateAdded);
        }
        [CacheRemoveAspect("IStateControlService.Get")]
        public IResult Delete(StateControl stateControl)
        {
            stateControl.ModifiedDate = DateTime.Now;
            stateControl.Status = 0;
            _stateControlDal.Update(stateControl);
            return new SuccessResult(Messages.StateDelete);
        }

        [CacheAspect]
        public IDataResult<List<StateControl>> GetAll()
        {
            return new SuccessDataResult<List<StateControl>>(_stateControlDal.GetAll(),Messages.Listed);
        }
        [CacheRemoveAspect("IStateControlService.Get")]
        public IResult Update(StateControl stateControl)
        {
            stateControl.ModifiedDate = DateTime.Now;
            _stateControlDal.Update(stateControl);
            return new SuccessResult(Messages.StateUpdate);
        }
    }
}
