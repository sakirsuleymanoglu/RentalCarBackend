using Microsoft.Extensions.DependencyInjection;
using RentalCar.Core.Utilities.IoC;

namespace RentalCar.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, params ICoreModule[] coreModules)
        {
            foreach (var coreModule in coreModules)
            {
                coreModule.Load(services);
            }

            return ServiceTool.Create(services);
        }
    }
}
