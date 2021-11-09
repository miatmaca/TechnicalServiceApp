using Core.Entities.Entity;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.DataAcces.IEntityRepository;

namespace DataAccess.Abstract
{
  public  interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        List<UserOperationDto> GetUserOperationDtos();
    }
}
