using NetCore.CodeCoverage.Abstractions.Services;

namespace NetCore.CodeCoverage.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Sum(int a, int b) 
            => a + b;

        public int Subtract(int a, int b)
            => a - b;

        public double Mult(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }

            return a * b;
        }
    }
}
