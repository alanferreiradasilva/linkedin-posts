using Dotnet.Guards.Api.Entities;
using Dotnet.Guards.Api.Repositories;
using Dotnet.Guards.Api.Services;
using NSubstitute;

namespace Dotnet.Guards.Tests
{
    public partial class ProductServiceTest
    {
        private readonly IProductRepository _repository;
        private readonly IProductService _service;

        public ProductServiceTest()
        {
            _repository = Substitute.For<IProductRepository>();
            _service = new ProductService(_repository);
        }

        private Product fakeProduct_GetAsync = new Product
        {
            Id = 1,
            Title = "Product 1",
            Description = "Description of Product 1",
            Price = 1000
        };

        private Product fakeProduct_CreateAsync = new Product
        {
            Id = 10,
            Title = "Product 10",
            Description = "Description of Product 10",
            Price = 5000
        };
    }
}
