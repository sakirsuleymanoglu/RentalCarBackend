using Castle.DynamicProxy;
using RentalCar.Core.CrossCuttingCorcerns.Caching;
using RentalCar.Core.Utilities.Interceptors;
using RentalCar.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace RentalCar.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        public string _pattern;
        public ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
