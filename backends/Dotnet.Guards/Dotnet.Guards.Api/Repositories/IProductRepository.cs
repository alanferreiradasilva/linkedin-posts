using Dotnet.Guards.Api.Entities;

namespace Dotnet.Guards.Api.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);
        Task<Product> CreateAsync(Product entity);
    }
}
