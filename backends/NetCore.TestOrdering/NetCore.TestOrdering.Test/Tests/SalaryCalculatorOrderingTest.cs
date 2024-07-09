using Shouldly;
using Xunit.Priority;

namespace NetCore.TestOrdering.Test.Tests
{
    public class SalaryCalculatorOrderingTest : BaseTestOrdering
    {
        public decimal _hundredPercent = 100;

        [Fact, Priority(0)]
        public void IncomeTaxRate()
        {
            SalaryCalculator.IncomeTaxRate = 15m / _hundredPercent;
            SalaryCalculator.IncomeTaxRate.ShouldBeGreaterThan(0);
        }

        [Fact, Priority(0)]
        public void SocialSecurityTax()
        {
            SalaryCalculator.SocialSecurityTax = 10m / _hundredPercent;
            SalaryCalculator.SocialSecurityTax.ShouldBeGreaterThan(0);
        }

        [Theory, Priority(1)]
        [InlineData(1000)]
        public void CalcNetSalary(decimal grossSalary)
        {
            SalaryCalculator.CalcDiscounts(grossSalary);
            SalaryCalculator.CalcNetSalary();

            SalaryCalculator.NetSalary.ShouldBeLessThan(grossSalary);
            SalaryCalculator.NetSalary.ShouldBeGreaterThan(SalaryCalculator.IncomeTaxRate);
            SalaryCalculator.NetSalary.ShouldBeGreaterThan(SalaryCalculator.SocialSecurityTax);
            SalaryCalculator.NetSalary.ShouldBeGreaterThan(0);
        }
    }

}
