using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Business.Validation.FluentValidation;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerdal;

        public CustomerManager(ICustomerDal customerdal)
        {
            _customerdal = customerdal;
        }

        [CacheRemoveAspect("ICustomerService.Get")]
      //  [SecuredOperation("Boss,Personel")]
        [ValidationAspect(typeof(CustomerValidator))]//Doğrulama 
        public IResult Add(Customer customer)
        {
            var result = _customerdal.Get(c => c.Gsm == customer.Gsm);
            if (result == null)
            {
                customer.CreatedDate = DateTime.Now;
                _customerdal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
            return new ErrorResult("Kullanıcı Numarası Kayıtlı");
        }
        // [SecuredOperation("Boss")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            customer.ModifiedDate = DateTime.Now;
            customer.Status = 0;
            _customerdal.Update(customer);
            return new SuccessResult(Messages.CustomerDelete);
        }
        //[CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerdal.GetAll());
        }
        public IDataResult<List<Customer>> GetCustomerGsm(string gsm)
        {
            return new SuccessDataResult<List<Customer>>(_customerdal.GetAll(c=>c.Gsm==gsm));
        }
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            customer.ModifiedDate = DateTime.Now;
            _customerdal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdate);
        }
    }
}
