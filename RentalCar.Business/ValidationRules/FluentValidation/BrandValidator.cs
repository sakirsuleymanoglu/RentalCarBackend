using FluentValidation;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(brand => brand.Name).NotNull();
            RuleFor(brand => brand.Name).MinimumLength(3);
        }
    }
}
