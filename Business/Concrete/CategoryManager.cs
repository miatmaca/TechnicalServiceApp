using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Core.Asbect.Autofac.Caching;
using Core.Asbect.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
         [CacheRemoveAspect("ICategoryService.Get")]
       // [ValidationAspect(typeof(ProductInfoValidator))]
       //  [SecuredOperation("Boss,Personel")]
        public IResult Add(Category category)
        {
            var result = CategoryNameControl(category);
            if (result.Success)
            {               
                category.ModifiedDate = DateTime.Now;
                category.CreatedDate = DateTime.Now; //Oluşturulduğu Tarih otomatik burdan 
               _categoryDal.Add(category);
                return new SuccessResult(Messages.Added);
            }

            return new ErrorResult("Girilen Kategori Sistemde Kayıtlı");
        }
        [CacheRemoveAspect("ICategoryService.Get")]
        // [ValidationAspect(typeof(ProductInfoValidator))]
      //  [SecuredOperation("Boss,Personel")]
        public IResult Delete(Category category)
        {
            category.ModifiedDate = DateTime.Now;
            category.Status = 0;
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Deleted);
        }
       // [CacheAspect]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<List<Category>> GetAllByStatusOne()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c=>c.Status==1));
        }

        public IDataResult<List<Category>> GetAllOemId(int oemId)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(p => p.OemId==oemId));
        }

        public Category GetCategory(string categoryName,int oemId)
        {
            var result = _categoryDal.Get(c => c.CategoryName == categoryName && c.OemId==oemId);
            return result;
        }

        [CacheRemoveAspect("ICategoryService.Get")]
        // [ValidationAspect(typeof(ProductInfoValidator))]
        //[SecuredOperation("Boss,Personel")]
        public IResult Update(Category category)
        {
            category.ModifiedDate = DateTime.Now;
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Update);
        }
        private IResult CategoryNameControl(Category category)
        {
            var result = _categoryDal.GetAll(c => c.CategoryName ==category.CategoryName && c.OemId==category.OemId);
            if (result.Count < 1)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }
    }
}
