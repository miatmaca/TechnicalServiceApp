using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
    class FaultInfoValidator: AbstractValidator<FaultInfo>
    {
        public FaultInfoValidator()
        {
            RuleFor(f => f.ProductId).NotEmpty().WithMessage("Ürün Bilgisini Giriniz"); 
            RuleFor(f=>f.EmployeeId).NotEmpty().WithMessage("Çalışan Bilgisini Giriniz");
            RuleFor(f=>f.CustomerId).NotEmpty();
            RuleFor(f=>f.ServiceStateId).NotEmpty();
          
        }
    
    }
}
