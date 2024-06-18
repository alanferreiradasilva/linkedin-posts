using BenchmarkDotNet.Attributes;
using NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Repositories;

namespace NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Benchmarks
{
    public class ProductBenchmark
    {
        static int NumberOfValidations = 100;

        public ProductBenchmark()
        {
            Setup();
        }

        private void Setup()
        {
            var repository = new ProductRepository();
            repository.RunSeed();
        }

        [Benchmark]
        public async Task SimpleDapperBenchmark()
        {
            var repository = new ProductRepository();
            for (int i = 0; i < NumberOfValidations; i++)
                await repository.GetSimpleDapper();
        }

        [Benchmark]
        public async Task DapperQueryMultipleBenchmark()
        {
            var repository = new ProductRepository();
            for (int i = 0; i < NumberOfValidations; i++)
                await repository.GetDapperQueryMultiple();
        }
    }
}
