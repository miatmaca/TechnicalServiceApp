using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductInfoService
    {
        IResult Add(ProductInfo productInfo);
        IResult Update(ProductInfo productInfo);
        IResult Delete(ProductInfo productInfo);
        IDataResult<List<ProductInfo>> GetAll();
    }
}
