using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Kullanıcı adı girilmelidir..!");
            RuleFor(p => p.FirstName).MaximumLength(50).WithMessage("Kullanıcı maksimum 50 karakter olmalıdır..!");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Kullanıcı soyadı girilmelidir..!");
            RuleFor(p => p.LastName).MaximumLength(50).WithMessage("Kullanıcı soyadı maksimum 50 karakter olmalıdır..!");
            RuleFor(p => p.Email).NotEmpty().WithMessage("E-mail adresi girilmelidir..!");
            RuleFor(p => p.Email).EmailAddress().WithMessage("E-mail adresi hatalı..!");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş geçilemez..!");
        }
    }
}
