using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanici Adi bos olamaz!");
            RuleFor(p => p.Name).MinimumLength(4).WithMessage("Kullanici Adi en az 4 karakter olmalidir!");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Mail bos olamaz!");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Mail adresi hatali!");
        }
    }
}
