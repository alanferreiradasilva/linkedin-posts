using Xunit.Priority;

namespace NetCore.TestOrdering.Test.Tests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public abstract class BaseTestOrdering
    {
    }
}
