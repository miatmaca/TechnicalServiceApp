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
    public class OemManager : IOemService
    {
        IOemDal _oemDal;

        public OemManager(IOemDal oemDal)
        {
            _oemDal = oemDal;
        }
        [CacheRemoveAspect("IOemService.Get")]
        public IResult Add(Oem oem)
        {
            var result = OemNameControl(oem);
            if (result.Success)
            {
                oem.Status = 1;
                oem.CreatedDate = DateTime.Now; //Oluşturulduğu Tarih otomatik burdan 
                oem.ModifiedDate = DateTime.Now;
                _oemDal.Add(oem);
                return new SuccessResult(Messages.Added);
            }

            return new ErrorResult("Girilen Ürün Sistemde Kayıtlı");
        }
        [CacheRemoveAspect("IOemService.Get")]
        public IResult Delete(Oem oem)
        {
            oem.ModifiedDate = DateTime.Now;
            _oemDal.Delete(oem);
            return new SuccessResult(Messages.Deleted);
        }
        [CacheAspect]
        public IDataResult<List<Oem>> GetAll()
        {
            return new SuccessDataResult<List<Oem>>(_oemDal.GetAll());
        }

        public IDataResult<List<Oem>> GetAllByStatusOne()
        {
            return new SuccessDataResult<List<Oem>>(_oemDal.GetAll(o=>o.Status==1));
        }

        public Oem GetOem(string oemName)
        {
            var result = _oemDal.Get(c => c.OemName == oemName);
            return result;
        }

        [CacheRemoveAspect("IOemService.Get")]
        public IResult Update(Oem oem)
        {
            oem.ModifiedDate = DateTime.Now;
            _oemDal.Update(oem);
            return new SuccessResult(Messages.Update);
        }
        private IResult OemNameControl(Oem oem)
        {
            var result = _oemDal.GetAll(c => c.OemName ==oem.OemName);
            if (result.Count < 1)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }

    }
}
