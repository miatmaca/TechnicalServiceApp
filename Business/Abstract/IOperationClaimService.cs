using Core.Entities.Entity;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IOperationClaimService
    {
        IResult Add(OperationClaim operationclaim);
        IResult Update(OperationClaim operationClaim);
        IResult Delete(OperationClaim  operationClaim);
        IDataResult<List<OperationClaim>> GetAll();
    }
}
