using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
       
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;

        }
         [SecuredOperation("Boss")]

        public IResult Add(Brand brand)
        {
            var result = BrandNameControl(brand);
            if (result.Success)

            {
                brand.Status = 1;
                brand.CreatedDate = DateTime.Now; //Oluşturulduğu Tarih otomatik burdan 
                brand.ModifiedDate = DateTime.Now;

                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }

            return new ErrorResult("Girilen Marka Sistemde Kayıtlı");


        }
        // [SecuredOperation("Boss")]
        public IResult Delete(Brand brand)
        {
           
            brand.ModifiedDate = DateTime.Now;//Değiştirildiği Tarih Otomatik Burdan
            brand.Status = 0;
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandDelete);
        }
        // [SecuredOperation("Boss,Personel")]

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<List<Brand>> GetAllByStatusOne()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b=>b.Status==1));
        }

        public Brand GetBrand(string brandName)
        {
            var result = _brandDal.Get(c=>c.BrandName==brandName);
            return result;
        }

         [SecuredOperation("Boss")]
        public IResult Update(Brand brand)
        {
            
            brand.ModifiedDate = DateTime.Now;
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdate);
        }
        private IResult BrandNameControl(Brand brand)
        {
            var result = _brandDal.GetAll(c => c.BrandName == brand.BrandName);
            if (result.Count < 1)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }
    }
}
