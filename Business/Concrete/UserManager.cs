using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Core.Asbect.Autofac.Caching;
using Core.Entities.Entity;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal employeeDal)
        {
            _userDal = employeeDal;
        }
        [CacheRemoveAspect("IEmployee.Get")]
        [SecuredOperation("Boss")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.EmployeeAdded);
        }
        [CacheRemoveAspect("IEmployee.Get")]
        [SecuredOperation("Boss")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.EmployeeDelete);
        }
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        [CacheRemoveAspect("IEmployee.Get")]
        [SecuredOperation("Boss")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.EmployeeUpdate);
        }

        [CacheAspect]
        [SecuredOperation("Boss")]
        public IDataResult<List<User>> GetByEmployeeId(int userId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(e=>e.Id==userId));
        }
        [SecuredOperation("Boss")]
        public User GetByMail(string email)
        {
            return  _userDal.Get(e => e.Email == email);
        }
        [SecuredOperation("Boss")]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
