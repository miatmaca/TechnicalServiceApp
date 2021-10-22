using Business.Abstract;
using Business.Constans;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EndDataManager : IEndDataService
    {
        IEndDataDal _endDataDal;

        public EndDataManager(IEndDataDal endDataDal)
        {
            _endDataDal = endDataDal;
        }

        public IResult Add(EndData endData)
        {
            endData.CreatedDate = DateTime.Now;
            _endDataDal.Add(endData);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(EndData endData)
        {
            endData.ModifiedDate = DateTime.Now;
            _endDataDal.Delete(endData);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<EndData>> GetAll()
        {
            return new SuccessDataResult<List<EndData>>(_endDataDal.GetAll());
        }

        public IResult Update(EndData endData)
        {
           endData.ModifiedDate = DateTime.Now;
            _endDataDal.Update(endData);
            return new SuccessResult(Messages.Update);
        }
        public IDataResult<List<CommonDto>> GetCommonDto()
        {
            return new SuccessDataResult<List<CommonDto>>(_endDataDal.GetCommonDto());
        }
    }
}
