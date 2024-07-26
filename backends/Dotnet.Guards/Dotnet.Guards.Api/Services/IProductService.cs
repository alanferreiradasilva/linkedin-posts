using Dotnet.Guards.Api.Entities;

namespace Dotnet.Guards.Api.Services
{
    public interface IProductService
    {
        Task<Product> GetAsync(int id);
        Task<Product> CreateAsync(Product entity);
    }
}
