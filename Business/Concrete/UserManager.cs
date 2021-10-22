using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Core.Asbect.Autofac.Caching;
using Core.Entities.Entity;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
     //   [SecuredOperation("Boss")]
        public IResult Add(User user)
        {

            user.CreatedDate = DateTime.Now;
            _userDal.Add(user);
            return new SuccessResult(Messages.EmployeeAdded);
        }
        [CacheRemoveAspect("IEmployee.Get")]
     //   [SecuredOperation("Boss")]
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
      //  [SecuredOperation("Boss")]
        public IResult Update(User user)
        {
            var result = _userDal.Get(c => c.Id == user.Id);
            user.PasswordHash = result.PasswordHash;
            user.PasswordSalt = result.PasswordSalt;
            user.CreatedBy = result.CreatedBy;
            user.CreatedDate = result.CreatedDate;
            user.ModifiedDate = DateTime.Now;
            _userDal.Update(user);
            return new SuccessResult(Messages.EmployeeUpdate);
        }

        [CacheAspect]
       // [SecuredOperation("Boss")]
        public IDataResult<List<User>> GetByEmployeeId(int userId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(e=>e.Id==userId));
        }
       // [SecuredOperation("Boss")]
        public User GetByMail(string email)
        {
            return  _userDal.Get(e => e.Email == email);
        }
      //  [SecuredOperation("Boss")]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
       public ClaimDto GetClaimControl(int userId)
        {
            return (_userDal.GetClaimControl(userId));
        }
       public IDataResult<List<User>> GetEmailByUserId(string email)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(c=>c.Email==email));
        }

        public User GetByUserId(int userId)
        {
            return (_userDal.Get(u=>u.Id==userId));
        }
    }
}
