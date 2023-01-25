using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ListingValidator:  AbstractValidator<Listing>
    {
        public ListingValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Listing adi bos olamaz");
            RuleFor(p => p.Name).MinimumLength(7).WithMessage("Listing adi en az 7 karakter olmali");

            RuleFor(p => p.BuyFromLink).NotEmpty().WithMessage("Listing indirme linki bos olamaz");
        }
    }
}
