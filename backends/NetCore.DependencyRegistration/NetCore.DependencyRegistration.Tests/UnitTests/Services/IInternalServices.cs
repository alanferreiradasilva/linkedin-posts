using NetCore.DependencyRegistration.Abstractions.Services;

namespace NetCore.DependencyRegistration.Tests.UnitTests.Services
{
    internal interface IInternalServices { }

    internal interface ITestOrderService : IBaseService
    {

    }

    internal interface ITestServiceA : IBaseService
    {
    }

    internal class TestServiceA : IInternalServices
    {
        public readonly ITestServiceB _serviceB;
        public TestServiceA(ITestServiceB serviceB)
        {
            _serviceB = serviceB;
        }
    }

    internal interface ITestServiceB : IBaseService
    {
    }

    internal class TestServiceB : ITestServiceB
    {
        public readonly ITestServiceA _serviceA;
        public TestServiceB(ITestServiceA serviceA)
        {
            _serviceA = serviceA;
        }
    }
}
