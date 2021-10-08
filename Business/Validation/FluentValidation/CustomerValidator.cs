using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
       public CustomerValidator()
        {
            RuleFor(c => c.GSM).NotEmpty();
            RuleFor(c => c.CustomerName).NotEmpty();
           

        }
    }
}
