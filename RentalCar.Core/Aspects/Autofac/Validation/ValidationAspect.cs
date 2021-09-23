﻿using Castle.DynamicProxy;
using FluentValidation;
using RentalCar.Core.CrossCuttingCorcerns.Validation.FluentValidation;
using RentalCar.Core.Utilities.Interceptors;
using System;
using System.Linq;

namespace RentalCar.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var entities = invocation.Arguments.Where(e => e.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
