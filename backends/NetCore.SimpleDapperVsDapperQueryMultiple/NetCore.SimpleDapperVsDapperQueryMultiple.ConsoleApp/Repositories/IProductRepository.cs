using NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Entities;

namespace NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetSimpleDapper();
        Task<IEnumerable<Product>> GetDapperQueryMultiple();
    }
}
