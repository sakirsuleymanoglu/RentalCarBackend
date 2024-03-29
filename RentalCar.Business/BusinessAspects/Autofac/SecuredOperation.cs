﻿using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using RentalCar.Core.Extensions;
using RentalCar.Core.Utilities.Interceptors;
using RentalCar.Core.Utilities.IoC;
using System;
using Microsoft.Extensions.DependencyInjection;
using RentalCar.Business.Utilities.Constants;

namespace RentalCar.Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private readonly string[] _roles;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');

            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }

            throw new Exception(Messages.UserNotAuthorized);
        }
    }
}
