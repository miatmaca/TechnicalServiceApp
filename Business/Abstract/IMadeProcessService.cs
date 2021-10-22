using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IMadeProcessService
    {
        IResult Add(MadeProces madeProces);
        IResult Update(MadeProces madeProces);
        IResult Delete(MadeProces madeProces);
        IDataResult<List<MadeProces>> GetAll();
       
        IDataResult<List<MadeProcesDto>> GetMadeProcessDto(int productId);

    }
}
