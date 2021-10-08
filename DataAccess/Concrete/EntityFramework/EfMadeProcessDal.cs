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
        public List<MadeProcesDto> GetMadeProcess(int productId)
        {
            using (TServiceContext context = new TServiceContext())
            {
                var result = from madeProces in context.MadeProcess
                             join state in context.StateControls
                             on madeProces.StateId equals state.StateId

                             join procesControl in context.ProcessControls
                             on madeProces.ProcessId equals procesControl.ProcessId

                             join employee in context.Users
                             on madeProces.EmployeeId equals employee.Id

                             join productInfo in context.ProductInfos
                             on madeProces.ProductId equals productInfo.ProductId

                             where madeProces.ProductId==productId
                             select new MadeProcesDto
                             {
                                 ProductId = madeProces.ProductId,
                                 EmployeeName=employee.FirstName,
                                 Price = procesControl.Price,
                                 Description=madeProces.Description,
                                 State=state.StateName,
                                 ProcessName=procesControl.ProcessName,
                                 ProductName=productInfo.ProductType

                             };


                return result.ToList();

             
            }
        }
    }
}
