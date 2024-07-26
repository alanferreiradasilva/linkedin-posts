using Dotnet.Guards.Api.Entities;
using Dotnet.Guards.Api.Repositories;
using GuardNet;

namespace Dotnet.Guards.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            Guard.NotNull(repository, nameof(repository));
            _repository = repository;
        }

        public Task<Product> CreateAsync(Product entity)
        {
            Guard.NotNull(entity, nameof(entity));

            return _repository.CreateAsync(entity);
        }

        public Task<Product> GetAsync(int id)
        {
            Guard.NotLessThan(id, 1, nameof(id));

            return _repository.GetAsync(id);
        }
    }
}
