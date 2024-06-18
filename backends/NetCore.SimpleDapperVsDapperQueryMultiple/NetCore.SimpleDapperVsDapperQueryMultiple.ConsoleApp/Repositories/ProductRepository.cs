using Dapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Entities;
using NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Seed;

namespace NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Private
        private const string ConnectionString = "Server=localhost,1433;Database=SimpleDapperVsDapperQueryMultiple_Db;User Id=SA;Password=YourPassword@123;TrustServerCertificate=True;";

        private SqlConnection GetConnection() => new SqlConnection(ConnectionString);
        #endregion

        #region SimpleDapper
        private const string PRODUCTS_QUERY = "SELECT * FROM Products";
        private const string PRODUCT_DETAILS_QUERY = "SELECT * FROM ProductDetails WHERE ProductId IN @Ids;";
        private const string CATEGORIES_QUERY = "SELECT * FROM Categories WHERE Id IN @Ids;";

        public async Task<IEnumerable<Product>> GetSimpleDapper()
        {
            using (var db = GetConnection())
            {
                var products = await db.QueryAsync<Product>(PRODUCTS_QUERY);

                if (products.Any())
                {
                    var productIds = products.Select(p => p.Id);

                    var details = await db.QueryAsync<ProductDetail>(PRODUCT_DETAILS_QUERY, new { Ids = productIds });
                    var categories = await db.QueryAsync<Category>(CATEGORIES_QUERY, new { Ids = products.Select(p => p.CategoryId) });
                    BuildProduct(products, categories, details);
                }

                return products;
            }
        }
        #endregion

        private const string PRODUCTS_COMPLETE_QUERY = @"
            SELECT * FROM ProductDetails WHERE ProductId IN @ProductIds;
            SELECT * FROM Categories WHERE Id IN @CategoriesIds;
        ";

        public async Task<IEnumerable<Product>> GetDapperQueryMultiple()
        {
            using (var db = GetConnection())
            {
                var products = await db.QueryAsync<Product>(PRODUCTS_QUERY);

                if (products.Any())
                {
                    var parameters = new { ProductIds = products.Select(p => p.Id), CategoriesIds = products.Select(p => p.CategoryId) };

                    using (var multi = await db.QueryMultipleAsync(PRODUCTS_COMPLETE_QUERY, parameters))
                    {
                        var details = await multi.ReadAsync<ProductDetail>();
                        var categories = await multi.ReadAsync<Category>();
                        BuildProduct(products, categories, details);
                    }
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

        public void RunSeed()
        {
            string sql = ProductSeed.GetSeed();

            using (var db = GetConnection())
            {
                db.Execute(sql);
            }
        }
    }
}
