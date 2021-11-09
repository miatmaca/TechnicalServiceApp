using Core.DataAcces.EntityFrameWork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace DataAccess.Concrete
{
    public class EfProductInfoDal : EfEntityRepositoryBase<ProductInfo, TServiceContext>, IProductInfoDal
    {
        public ProductInfoDto GetAllDto(int productId)
        {
            using (TServiceContext context = new TServiceContext())
            {

                var result = from productInfo in context.ProductInfos
                             where productInfo.ProductId == productId

                             join customer in context.Customers
                             on productInfo.CustomerId equals customer.Id

                             join user in context.Users
                             on productInfo.CreatedBy equals user.Id

                             join stateControl in context.StateControls
                             on productInfo.StateControl equals stateControl.Id

                             join oem in context.Oems
                           on productInfo.OemName equals oem.Id
                             select new ProductInfoDto
                             {
                                 ProductId = productInfo.ProductId,
                                 brandName = productInfo.BrandName,
                                 OemName = oem.OemName,
                                 Category = productInfo.CategoryName,
                                 SerialNo = productInfo.SerialNo,
                                 FaultName = productInfo.FaultName,
                                 StateName = stateControl.StateName,
                                 CustomerName = customer.FirstName + " " + customer.LastName,
                                 CreatedDate = productInfo.CreatedDate,
                                 UserNameSurname = user.FirstName + " " + user.LastName,
                                 Gsm = customer.Gsm

                             };

                return result.SingleOrDefault();
            }

        }
        public List<ProductInfoDto> GetAllByFilter(Expression<Func<ProductInfoDto, bool>> filter = null)
        {
            using (TServiceContext context = new TServiceContext())
            {
                var result = from productInfo in context.ProductInfos


                             join customer in context.Customers
                             on productInfo.CustomerId equals customer.Id

                             join user in context.Users
                             on productInfo.CreatedBy equals user.Id

                             join stateControl in context.StateControls
                             on productInfo.StateControl equals stateControl.Id

                             join oem in context.Oems
                             on productInfo.OemName equals oem.Id

                             select new ProductInfoDto
                             {
                                 ProductId = productInfo.ProductId,
                                 brandName =productInfo.BrandName,
                                 OemName = oem.OemName,
                                 Category = productInfo.CategoryName,
                                 SerialNo = productInfo.SerialNo,
                                 FaultName = productInfo.FaultName,
                                 StateName = stateControl.StateName,
                                 CustomerName = customer.FirstName + " " + customer.LastName,
                                 CreatedDate = productInfo.CreatedDate,
                                 UserNameSurname = user.FirstName + " " + user.LastName,
                                 Gsm = customer.Gsm,
                                  Status=productInfo.Status
                                 

                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }

        }
        public List<EndDataDto> GetAllEndDataDto(int productId)
        {
            using (TServiceContext context = new TServiceContext())
            {

                var result = from productInfo in context.ProductInfos
                             where productInfo.ProductId == productId
                           
                             join madeProcess in context.MadeProcess
                             on productInfo.ProductId equals madeProcess.ProductId
                             
                             join procesState in context.ProcesStates
                             on madeProcess.MadeProcess equals procesState.Id
                             select new EndDataDto
                             {
                                 ProductId = productInfo.ProductId,
                                 CustomerId=productInfo.CustomerId,
                                 MadeProcess=madeProcess.MadeProcess,
                                 Price=procesState.Price


                             };

                return result.ToList();
            }
        }


    }
}
