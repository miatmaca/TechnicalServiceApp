using Core.DataAcces.EntityFrameWork;
using Core.Entities.Entity;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, TServiceContext>, IUserOperationClaimDal
    {
        public List<UserOperationDto> GetUserOperationDtos()
        {

            using (TServiceContext context = new TServiceContext())
            {
                var result = from user in context.Users
                             join userOperationClaim in context.UserOperationClaims
                             on user.Id equals userOperationClaim.UserId

                              into list1
                             from l1 in list1.DefaultIfEmpty()

                             join  operationClaim in context.OperationClaims
                             on l1.OperationClaimId equals operationClaim.Id                             
                             
                             into list2 from l2 in list2.DefaultIfEmpty()
                             
                             select new UserOperationDto
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,                                
                                 Email = user.Email,
                                 Gsm = user.Gsm,
                                Claim=l2.OperationName
                                 


                             };


                return result.ToList();
            }
        }
        }
    }

