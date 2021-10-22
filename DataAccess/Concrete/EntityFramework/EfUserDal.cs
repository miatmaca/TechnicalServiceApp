using Core.DataAcces.EntityFrameWork;
using Core.Entities.Entity;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, TServiceContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new TServiceContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, OperationName = operationClaim.OperationName };
                return result.ToList();
            }
        }
        public ClaimDto GetClaimControl(int userId)
        {
            using (var context = new TServiceContext())
            {
                var result = from userOperationClaim in context.UserOperationClaims
                             join operationClaim in context.OperationClaims
                             on userOperationClaim.OperationClaimId equals operationClaim.Id
                             where userOperationClaim.UserId==userId

                             select new ClaimDto {  userId = userId,  ClaimName  = operationClaim.OperationName };
               
                return result.SingleOrDefault();
            }
        }
    }  
    
      
    

}
