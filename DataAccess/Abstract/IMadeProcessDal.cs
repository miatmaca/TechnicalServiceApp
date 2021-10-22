using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.DataAcces.IEntityRepository;

namespace DataAccess.Abstract
{
    public interface IMadeProcessDal : IEntityRepository<MadeProces>
    {
        List<MadeProcesDto> GetMadeProcessDto(int productId);
      
    }
}
