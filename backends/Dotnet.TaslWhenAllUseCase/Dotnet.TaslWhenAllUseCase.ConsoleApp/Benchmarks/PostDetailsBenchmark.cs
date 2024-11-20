using BenchmarkDotNet.Attributes;
using Dotnet.TaslWhenAllUseCase.ConsoleApp.Entities;
using Dotnet.TaslWhenAllUseCase.ConsoleApp.Services;

namespace Dotnet.TaslWhenAllUseCase.ConsoleApp.Benchmarks
{
    public class PostDetailsBenchmark
    {
        static int NumberOfValidations = 100;
        static List<string> codes = new List<string> { "POST-123", "POST-456", "POST-789", "POST-012", "POST-345" };
        
        [Benchmark]
        public async Task RunningWithForeach()
        {
            var postService = new PostService();

            for (int i = 0; i < NumberOfValidations; i++)            
            {
                var postDetails = new List<PostDetails>();
                foreach (var code in codes) {
                    postDetails.Add(await postService.GetPostDetails(code));
                }
            }
        }

        [Benchmark]
        public async Task RunningWithWhenAll()
        {
            var postService = new PostService();

            for (int i = 0; i < NumberOfValidations; i++)
            {
                var postDetails = new List<PostDetails>();                
                var tasks = codes.AsParallel().Select(code => postService.GetPostDetails(code));
                postDetails = (await Task.WhenAll(tasks)).ToList();
            }
        }
    }
}
