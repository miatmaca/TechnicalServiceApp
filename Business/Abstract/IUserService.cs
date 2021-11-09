using Core.Entities.Entity;
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult PasswordUpdate(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetByEmployeeId(int userId);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<User>> GetEmailByUserId(string email);
        User GetByUserId(int userId);
        ClaimDto GetClaimControl(int userId);//Claimdto UserId ve ClaimName gelir userId sine göre



    }
}
