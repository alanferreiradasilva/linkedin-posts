namespace NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public IEnumerable<ProductDetail> Details { get; set; }
    }
}
