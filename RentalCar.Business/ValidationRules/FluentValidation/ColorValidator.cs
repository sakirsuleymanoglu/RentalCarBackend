using FluentValidation;
using RentalCar.Entities.Concrete;

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
