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
    public class EfMadeProcessDal : EfEntityRepositoryBase<MadeProces, TServiceContext>, IMadeProcessDal
    {
        public List<MadeProcesDto> GetMadeProcessDto(int productId)
        {
            using (TServiceContext context = new TServiceContext())
            {
                var result = from madeProces in context.MadeProcess
                             where madeProces.ProductId == productId

                             join stateControl in context.StateControls
                             on madeProces.StateControl equals stateControl.Id

                             join procesControl in context.ProcesStates
                             on madeProces.MadeProcess equals procesControl.Id

                             join user in context.Users
                             on madeProces.CreatedBy equals user.Id


                             join productInfo in context.ProductInfos
                             on madeProces.ProductId equals productInfo.ProductId

                             join customer in context.Customers
                             on productInfo.CustomerId equals customer.Id


                             where madeProces.ProductId == productId
                             select new MadeProcesDto
                             {
                                 ProductId = madeProces.ProductId,
                                 CreatedBy = user.FirstName + user.LastName,
                                 Price = procesControl.Price,
                                 CreatedDate = madeProces.CreatedDate,
                                 FaultName = madeProces.FaultName,
                                 MadeProcess = procesControl.ProcessName,
                                 ModifiedBy = user.FirstName,
                                 ModifiedDate = madeProces.ModifiedDate,                                
                                 StateNote = madeProces.StateNote,
                                 BrandName = productInfo.BrandName,
                                 CategoryName = productInfo.CategoryName,
                                 OemName = productInfo.OemName,
                                 SerialNo = productInfo.SerialNo,
                                 StateControl=stateControl.StateName,
                                 Customer=customer.FirstName,
                                  Gsm =customer.Gsm
                                


                             };


                return result.ToList();


            }
        }
    }
}
