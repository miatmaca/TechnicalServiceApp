using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
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
        IDataResult<List<ProductInfoDto>> GetAllByFilterDto(int productId);//Şartlı Getirm İşlemi
        // ProductInfo Adet Çekme
        IDataResult<List<ProductInfo>> NumberOfItemsInAccepted();//Tamirdeki Ürün sayısı
        IDataResult<List<ProductInfo>> NumberOfItemsInService();//Servisteki Ürün sayısı
        IDataResult<List<ProductInfo>> NumberOfItemsInReady();//Teslime Hazır Ürün sayısı

        IDataResult<List<ProductInfoDto>> GetService(string stateName);//Durum Bilgisine Göre Veri Çekme


        IDataResult<List<ProductInfoDto>> GetProductInfoDto();

        ProductInfo GetProduct(int id);


        ProductInfoDto GetAllByProductId(int productId);


        IDataResult<List<EndDataDto>> GetAllEndDataDto(int productId);
    }
}
