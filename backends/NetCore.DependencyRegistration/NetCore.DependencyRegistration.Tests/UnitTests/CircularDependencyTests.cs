using Microsoft.Extensions.DependencyInjection;
using NetCore.DependencyRegistration.Tests.UnitTests.Services;

namespace NetCore.DependencyRegistration.Tests.UnitTests
{
    public class CircularDependencyTests
    {
        [Fact]
        public void ResolvingServiceWithCircularDependency_ShouldThrowException()
        {
            // Arrange
            var services = new ServiceCollection();

            // Register services with circular dependencies
            services.AddSingleton<IInternalServices, TestServiceA>();
            services.AddSingleton<ITestServiceB, TestServiceB>();

            // Act & Assert
            var serviceProvider = services.BuildServiceProvider();

            // Try to resolve one of the services and expect an exception
            Assert.Throws<InvalidOperationException>(() =>
            {
                var serviceA = serviceProvider.GetService<IInternalServices>();
            });
        }
    }
}
