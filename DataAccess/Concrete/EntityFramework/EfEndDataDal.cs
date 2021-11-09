using Core.DataAcces.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfEndDataDal : EfEntityRepositoryBase<EndData, TServiceContext>, IEndDataDal
    {
        public List<CommonDto> GetCommonDto()
        {

            using (TServiceContext context = new TServiceContext())
            {
                var result = from productInfo in context.ProductInfos
                             join stateControl in context.StateControls
                             on productInfo.StateControl equals stateControl.Id

                             join customer in context.Customers
                             on productInfo.CustomerId equals customer.Id

                             join user in context.Users
                             on productInfo.CreatedBy equals user.Id

                             join madeProcess in context.MadeProcess
                             on productInfo.ProductId equals madeProcess.ProductId

                             join processControl in context.ProcesStates
                             on madeProcess.MadeProcess equals processControl.Id
                             join oem in context.Oems
                           on productInfo.OemName equals oem.Id

                             select new CommonDto
                             {  //Ürün Bilgileri
                                 ProductId = productInfo.ProductId,
                                 BrandName = productInfo.BrandName,
                                 OemName = oem.OemName,
                                 CategoryName = productInfo.CategoryName,
                                 SerialNo = productInfo.SerialNo,
                                 FaultName = productInfo.FaultName,
                                 CreatedDate = productInfo.CreatedDate,
                                 ModifiedDate = productInfo.ModifiedDate,
                                 //Müşteri Bilgileri
                                 CustomerId = customer.Id,
                                 CustomerFirstName = customer.FirstName,
                                 CustomerLastName = customer.LastName,
                                 CustomerEmail = customer.Email,
                                 CustomerGsm = customer.Gsm,
                                 //Personel Bilgileri
                                 CreatedBy = productInfo.CreatedBy,
                                 UserFirstName = user.FirstName,
                                 UserLastName = user.LastName,
                                 UserGsm = user.Gsm,

                                 StateName = stateControl.StateName,
                                 StateNote = madeProcess.StateNote,
                                 Status = productInfo.Status,
                                 MadeProcess = processControl.ProcessName,
                                 Price = processControl.Price,



                             };


                return result.ToList();
            }
        }
    }
}


