using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Business.Validation.FluentValidation;
using Core.Asbect.Autofac.Caching;
using Core.Asbect.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        [ValidationAspect(typeof(ProductInfoValidator))]
       // [SecuredOperation("Boss,Personel")]
        public IResult Add(ProductInfo productInfo)
        {
            productInfo.CreatedDate = DateTime.Now;
            productInfo.Status = 1;
            _productInfoDal.Add(productInfo);

            return new SuccessResult(Messages.productInfoAdded);
        }
       public ProductInfo GetProduct(int id)
        {
          return   _productInfoDal.Get(p=>p.ProductId == id);
        }
        [CacheRemoveAspect("IProductInfoService.Get")]
        public IResult Delete(ProductInfo productInfo)
        {
            
            _productInfoDal.Delete(productInfo);
            return new SuccessResult(Messages.productInfoDelete);
        }
      //  [CacheAspect]
        public IDataResult<List<ProductInfo>> GetAll()
        {
            return new SuccessDataResult<List<ProductInfo>>(_productInfoDal.GetAll());
        }

        public IDataResult<List<ProductInfoDto>> GetProductInfoDto()
        {

            return new SuccessDataResult<List<ProductInfoDto>>(_productInfoDal.GetAllByFilter(c=>c.Status==1));
        }

      
        [CacheRemoveAspect("IProductInfoService.Get")]
        public IResult Update(ProductInfo productInfo)
        {

            productInfo.ModifiedDate = DateTime.Now;
            _productInfoDal.Update(productInfo);
            return new SuccessResult(Messages.productInfoUpdate);
        }

        public IDataResult<List<ProductInfo>> NumberOfItemsInAccepted()
        {
            var result = _productInfoDal.GetAll(p => p.StateControl == 1);
            return new SuccessDataResult<List<ProductInfo>>(result);
        }

        public IDataResult<List<ProductInfo>> NumberOfItemsInService()
        {
            var result = _productInfoDal.GetAll(p => p.StateControl == 2);
            return new SuccessDataResult<List<ProductInfo>>(result);
        }

        public IDataResult<List<ProductInfo>> NumberOfItemsInReady()
        {
            var result = _productInfoDal.GetAll(p => p.StateControl == 3);
            return new SuccessDataResult<List<ProductInfo>>(result);
        }
       public IDataResult<List<ProductInfoDto>> GetService(string stateName)
        {
            return new SuccessDataResult<List<ProductInfoDto>>(_productInfoDal.GetAllByFilter(c=>c.StateName== stateName));
        }

        public IDataResult<List<ProductInfoDto>> GetAllByFilterDto(int productId)
        {
            return new SuccessDataResult<List<ProductInfoDto>>(_productInfoDal.GetAllByFilter(c => c.ProductId == productId));
        }

       public ProductInfoDto GetAllByProductId(int productId)
        {
            var result = _productInfoDal.GetAllDto(productId);
            return result;
        }

        public IDataResult<List<EndDataDto>> GetAllEndDataDto(int productId)
        {
            return new SuccessDataResult<List<EndDataDto>>(_productInfoDal.GetAllEndDataDto(productId));
        }
    }
}
