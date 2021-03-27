using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RentalCar.Core.CrossCuttingCorcerns.Caching;
using RentalCar.Core.CrossCuttingCorcerns.Caching.Microsoft;
using RentalCar.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RentalCar.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
