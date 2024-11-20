using Dotnet.TaslWhenAllUseCase.ConsoleApp.Entities;

namespace Dotnet.TaslWhenAllUseCase.ConsoleApp.Services
{
    public class PostService : IPostService
    {
        public Task<PostDetails> GetPostDetails(string postCode)
        {
            //Task.Delay(10);
            var result = PostDetails.GetList().FirstOrDefault(x => x.PostCode == postCode);
            return Task.FromResult<PostDetails>(result);
        }
    }
}
