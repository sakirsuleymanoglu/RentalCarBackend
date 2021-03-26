using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RentalCar.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
