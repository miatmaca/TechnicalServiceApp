using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
   public class ChangePasswordValidator : AbstractValidator<ChangePassword>
    {
        public ChangePasswordValidator()
        {
            RuleFor(c => c.NewPassword).NotEmpty();
            RuleFor(c => c.NewPassword).NotNull();
            RuleFor(c => c.NewPassword).MinimumLength(6).WithMessage("En az 6 karakter giriniz");
            RuleFor(c => c.NewPassword).MaximumLength(25).WithMessage("25 Karakterden Fazla Giremezsiniz");

            

            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Email).NotNull();
          




        }
    }
}
