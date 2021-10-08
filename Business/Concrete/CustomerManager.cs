using Business.Abstract;
using Business.Constans;
using Business.Validation.FluentValidation;
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

       
        [ValidationAspect(typeof(CustomerValidator))]//Doğrulama 
        public IResult Add(Customer customer)
        {
            _customerdal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
            
        }

        public IResult Delete(Customer customer)
        {
            _customerdal.Delete(customer);
            return new SuccessResult(Messages.CustomerDelete);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerdal.GetAll());
        }

        public IResult Update(Customer customer)
        {
            _customerdal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdate);
        }
    }
}
