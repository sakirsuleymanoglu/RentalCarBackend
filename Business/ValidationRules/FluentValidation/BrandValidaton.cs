using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidaton : AbstractValidator<Brand>
    {
        public BrandValidaton()
        {
            RuleFor(b => b.Name).NotEmpty();
        }
    }
}
