﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.DataAcces.IEntityRepository;

namespace DataAccess.Abstract
{
   public interface IEndDataDal : IEntityRepository<EndData>
    {
        public List<CommonDto> GetCommonDto();
    }
}
