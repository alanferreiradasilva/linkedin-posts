using Dotnet.Guards.Api.Entities;
using NSubstitute;
using Shouldly;

namespace Dotnet.Guards.Tests
{
    public partial class ProductServiceTest
    {
        [Theory]
        [InlineData(1)]
        public async Task GetAsync(int id)
        {
            _repository.GetAsync(id).Returns(fakeProduct_GetAsync);

            var entity = await _service.GetAsync(id);

            entity.ShouldNotBeNull();
            entity.Id.ShouldBe(id);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var entity = fakeProduct_CreateAsync;
            _repository.CreateAsync(entity).Returns(entity);

            var newEntity = await _service.CreateAsync(entity);

            newEntity.ShouldNotBeNull();
            newEntity.ShouldBeEquivalentTo(entity);
        }

        [Theory]
        [InlineData(0)]
        public async Task GetAsync_ArgumentOutOfRangeException(int id)
        {
            await Should.ThrowAsync<ArgumentOutOfRangeException>(async () =>
            {
                var entity = await _service.GetAsync(id);
            });
        }

        [Fact]
        public async Task CreateAsync_ArgumentNullException()
        {
            await Should.ThrowAsync<ArgumentNullException>(async () =>
            {
                Product entity = null;
                var newEntity = await _service.CreateAsync(entity);
            });
        }
    }
}
