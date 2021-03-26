using Microsoft.Extensions.DependencyInjection;
using RentalCar.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, params ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}
