namespace NetCore.CodeCoverage.Abstractions.Services
{
    public interface ICalculatorService
    {
        int Sum(int a, int b);
        int Subtract(int a, int b);
        double Mult(int a, int b);
    }
}
