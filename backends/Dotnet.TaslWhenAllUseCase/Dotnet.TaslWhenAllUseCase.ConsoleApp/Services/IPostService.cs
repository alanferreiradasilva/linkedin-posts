using Dotnet.TaslWhenAllUseCase.ConsoleApp.Entities;

namespace Dotnet.TaslWhenAllUseCase.ConsoleApp.Services
{
    public interface IPostService
    {
        Task<PostDetails> GetPostDetails(string postCode);
    }
}
