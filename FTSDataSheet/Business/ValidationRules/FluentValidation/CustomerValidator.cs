using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.CustomerCode).NotEmpty().WithMessage("Firma kodu girilmelidir..!");
            RuleFor(p => p.DisplayName).NotEmpty().WithMessage("Firma adı girilmelidir..!");
            RuleFor(p => p.DisplayName).MaximumLength(30).WithMessage("Firma Adı en az 5 en çok 30 karakter olmalıdır..!");
            RuleFor(p => p.CommercialTitle).NotEmpty().WithMessage("Firma ticari ünvanı girilmelidir..!");
        }
    }
}
