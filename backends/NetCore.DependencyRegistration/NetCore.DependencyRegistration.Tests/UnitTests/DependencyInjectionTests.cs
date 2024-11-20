using Microsoft.Extensions.DependencyInjection;
using NetCore.DependencyRegistration.Abstractions.Services;
using System.Reflection;
using NetCore.DependencyRegistration.IoC.Extensions;

namespace NetCore.DependencyRegistration.Tests.UnitTests
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void AddCustomService_ShouldRegisterAllBaseServicesInCore()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddCustomServices();
            var serviceProvider = services.BuildServiceProvider(validateScopes: true);

            // Act: Identify IBaseService implementations in the Core assembly
            var coreAssembly = Assembly.Load("NetCore.DependencyRegistration.Core");
            var baseServiceType = typeof(IBaseService);
            var coreServiceTypes = coreAssembly.GetTypes()
                                               .Where(t => 
                                                    baseServiceType.IsAssignableFrom(t) 
                                                    && t.IsInterface 
                                                    && t != baseServiceType
                                               );

            // Assert: Ensure all core services are registered
            foreach (var serviceType in coreServiceTypes)
            {
                var service = serviceProvider.GetService(serviceType);
                Assert.NotNull(service);  // Service should be registered
                Assert.IsAssignableFrom(serviceType, service);
            }
        }

        [Fact]
        public void UnregisteredInterfaces_ShouldNotBeResolvable()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddCustomServices();
            var serviceProvider = services.BuildServiceProvider(validateScopes: true);

            // Act: Identify IBaseService implementations in the test assembly
            var testAssembly = Assembly.GetExecutingAssembly();
            var baseServiceType = typeof(IBaseService);
            var testServiceTypes = testAssembly.GetTypes()
                                               .Where(t => 
                                                    baseServiceType.IsAssignableFrom(t) 
                                                    && t.IsInterface 
                                                    && t != baseServiceType
                                               );

            // Assert: Ensure all test-specific services are NOT registered
            foreach (var serviceType in testServiceTypes)
            {
                var service = serviceProvider.GetService(serviceType);
                Assert.Null(service);  // Service should not be registered
            }
        }        
    }
}