using BenchmarkDotNet.Attributes;
using NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Repositories;

namespace NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Benchmarks
{
    internal class ProductBenchmark
    {
        private readonly ProductRepository _repository = new ProductRepository();

        [Benchmark]
        public async Task SimpleDapperBenchmark()
        {
            await _repository.GetSimpleDapper();
        }

        [Benchmark]
        public async Task DapperQueryMultipleBenchmark()
        {
            await _repository.GetDapperQueryMultiple();
        }
    }
}
