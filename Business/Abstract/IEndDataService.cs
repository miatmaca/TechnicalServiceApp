using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IEndDataService
    {
        IResult Add(EndData endData);
        IResult Update(EndData endData);
        IResult Delete(EndData endData);
        IDataResult<List<EndData>> GetAll();
       IDataResult <List<CommonDto>> GetCommonDto();
    }
}
