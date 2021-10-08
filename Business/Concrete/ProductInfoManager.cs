using Business.Abstract;
using Business.Constans;
using Core.Asbect.Autofac.Caching;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductInfoManager : IProductInfoService
    {
        IProductInfoDal _productInfoDal;

        public ProductInfoManager(IProductInfoDal productInfoDal)
        {
            _productInfoDal = productInfoDal;
        }
        [CacheRemoveAspect("IProductInfoService.Get")]
        public IResult Add(ProductInfo productInfo)
        {
            _productInfoDal.Add(productInfo);

            return new SuccessResult(Messages.productInfoAdded);
        }
        [CacheRemoveAspect("IProductInfoService.Get")]
        public IResult Delete(ProductInfo productInfo)
        {
            _productInfoDal.Delete(productInfo);
            return new SuccessResult(Messages.productInfoDelete);
        }
        [CacheAspect]
        public IDataResult<List<ProductInfo>> GetAll()
        {
            return new SuccessDataResult<List<ProductInfo>>(_productInfoDal.GetAll(),Messages.productInfoListed);
        }
        [CacheRemoveAspect("IProductInfoService.Get")]
        public IResult Update(ProductInfo productInfo)
        {
            _productInfoDal.Update(productInfo);
            return new SuccessResult(Messages.productInfoUpdate);
        }
    }
}
