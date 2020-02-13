using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class DataSheetValidator : AbstractValidator<DataSheet>
    {
        public DataSheetValidator()
        {
            RuleFor(p => p.Department).NotEmpty().WithMessage("Departman girilmelidir..!");
            RuleFor(p => p.Contact).NotEmpty().WithMessage("Firma ilgilisi girilmelidir..!");
            RuleFor(p => p.MainCustomer).NotEmpty().WithMessage("Ana müşteri girilmelidir..!");
            RuleFor(p => p.TelephoneNumber).NotEmpty().WithMessage("Telefon numarası girilmelidir..!");
            RuleFor(p => p.EmailAddress).NotEmpty().WithMessage("E-mail adresi girilmelidir..!");
            RuleFor(p => p.EmailAddress).EmailAddress().WithMessage("E-mail hatalı..!");
        }
    }
}
