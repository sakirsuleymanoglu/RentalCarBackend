using FluentValidation;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).MinimumLength(3);
        }
    }
}
