using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Entity
{
  public  class UserOperationClaim:EntitiesBase
    {
      
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
