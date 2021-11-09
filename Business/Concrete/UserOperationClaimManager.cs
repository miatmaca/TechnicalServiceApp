using Business.Abstract;
using Core.Entities.Entity;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            userOperationClaim.CreatedDate = DateTime.Now;
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult("Kullanıcı Yetkisi İlişkilendirildi");
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult("Silindi");
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }

        public IDataResult< List<UserOperationDto>> GetUserOperationDtos()//Dto
        {
            return new SuccessDataResult<List<UserOperationDto>>(_userOperationClaimDal.GetUserOperationDtos());
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult("Kullanıcı Yetkisi İlişkisi Güncellendi");
        }
    }
}
