using NetCore.CodeCoverage.Abstractions.Services;
using NetCore.CodeCoverage.Core.Services;

namespace NetCore.CodeCoverage.Tests.Units
{
    public class CalculatorServiceTest
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorServiceTest()
        {
            _calculatorService = new CalculatorService();
        }

        [Fact]
        public void Sum_ShouldReturnCorrectResult()
        {
            // Arrange
            (int a, int b, int expectedResult) data = (5, 3, 8);

            // Act
            int result = _calculatorService.Sum(data.a, data.b);

            // Assert
            Assert.Equal(data.expectedResult, result);
        }        

        [Fact]
        public void Subtract_ShouldReturnCorrectResult()
        {
            // Arrange
            (int a, int b, int expectedResult) data = (5, 3, 2);

            // Act
            int result = _calculatorService.Subtract(data.a, data.b);

            // Assert
            Assert.Equal(data.expectedResult, result);
        }

        [Fact]
        public void Multi_ShouldReturnCorrectResult()
        {
            // Arrange
            (int a, int b, int expectedResult) data = (5, 3, 15);

            // Act
            double result = _calculatorService.Mult(data.a, data.b);

            // Assert
            Assert.Equal(data.expectedResult, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(-1, 1, 0)]
        [InlineData(100, -50, 50)]
        public void Sum_ShouldReturnCorrectResult_ForVariousInputs(int a, int b, int expectedResult)
        {
            // Act
            int result = _calculatorService.Sum(a, b);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(0, 1, 0)]
        [InlineData(5, 0, 0)]
        public void Multi_ShouldReturnCorrectResult_ForVariousInputs(int a, int b, int expectedResult)
        {
            // Act
            double result = _calculatorService.Mult(a, b);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
