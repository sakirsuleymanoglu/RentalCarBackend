using Microsoft.Extensions.DependencyInjection;

namespace RentalCar.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
