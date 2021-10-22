using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
    class ProductInfoValidator : AbstractValidator<ProductInfo>
    {
        public ProductInfoValidator()
        {
            RuleFor(p => p.BrandName).NotEmpty();
            RuleFor(p=>p.OemName).NotEmpty();
            RuleFor(p => p.SerialNo).NotEmpty();
            RuleFor(p => p.FaultName).NotEmpty();
           // RuleFor(p => p.StateName).NotEmpty();
           // RuleFor(p => p.).NotEmpty();



        }
    
    }
}
