using Microsoft.Extensions.DependencyInjection;
using NetCore.DependencyRegistration.Abstractions.Services;
using NetCore.DependencyRegistration.Core.Services;

namespace NetCore.DependencyRegistration.IoC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ServiceCollection AddCustomServices(this ServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>()
                .AddSingleton<ICustomerService, CustomerService>()
                ;

            return services;
        }
    }
}
