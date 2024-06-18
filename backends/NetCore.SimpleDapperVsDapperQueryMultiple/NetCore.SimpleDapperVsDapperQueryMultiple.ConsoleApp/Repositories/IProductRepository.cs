using NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Entities;

namespace NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Repositories
{
    public interface IProductRepository
    {
        void RunSeed();
        Task<IEnumerable<Product>> GetSimpleDapper();
        Task<IEnumerable<Product>> GetDapperQueryMultiple();
    }
}
