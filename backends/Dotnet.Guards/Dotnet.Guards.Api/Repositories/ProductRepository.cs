using Dotnet.Guards.Api.Entities;
using GuardNet;
using Microsoft.Extensions.Caching.Memory;

namespace Dotnet.Guards.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> CreateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
