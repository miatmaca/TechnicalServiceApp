using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using static Core.DataAcces.IEntityRepository;

namespace DataAccess.Abstract
{
   public interface IProductInfoDal : IEntityRepository<ProductInfo>
    {
        ProductInfoDto GetAllDto(int productId); // Tek döner
        List<ProductInfoDto> GetAllByFilter(Expression<Func<ProductInfoDto, bool>> filter = null);

        List<EndDataDto> GetAllEndDataDto(int productId);



    }
}
