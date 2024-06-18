using Dapper;
using Microsoft.Data.Sqlite;
using NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Entities;

namespace NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private const string ConnectionString = "Data Source=your_database.db";


        public async Task<IEnumerable<Product>> GetSimpleDapper()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                var products = await connection.QueryAsync<Product>("SELECT * FROM Products");

                if (products.Any())
                {
                    var productIds = products.Select(p => p.Id);

                    var details = await connection.QueryAsync<ProductDetail>("SELECT * FROM ProductDetail WHERE ProductId IN @Ids;", new { Ids = productIds });

                    var categories = await connection.QueryAsync<Category>("SELECT * FROM Categories WHERE Id IN @Ids;", new { Ids = products.Select(p => p.CategoryId) });

                    BuildProduct(products, categories, details);
                }

                return products;
            }
        }

        public async Task<IEnumerable<Product>> GetDapperQueryMultiple()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                var products = await connection.QueryAsync<Product>("SELECT * FROM Products;");

                if (!products.Any())
                {
                    return products;
                }

                var parameters = new
                {
                    ProductIds = products.Select(p => p.Id),
                    CategoriesIds = products.Select(p => p.CategoryId)
                };

                using (var multi = await connection.QueryMultipleAsync(
                    @"
                        SELECT * FROM ProductDetail WHERE ProductId IN @ProductIds;
                        SELECT * FROM Categories WHERE Id IN @CategoriesIds;
                    ", parameters))
                {
                    var details = await multi.ReadAsync<ProductDetail>();
                    var categories = await multi.ReadAsync<Category>();

                    BuildProduct(products, categories, details);
                }

                return products;
            }
        }

        private void BuildProduct(IEnumerable<Product> products, IEnumerable<Category> categories, IEnumerable<ProductDetail> details)
        {
            foreach (var product in products)
            {
                product.Details = details.Where(x => x.ProductId == product.Id);
                product.Category = categories.Single(x => x.Id == product.CategoryId);
            }
        }
    }
}
