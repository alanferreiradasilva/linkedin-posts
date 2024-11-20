namespace Dotnet.TaslWhenAllUseCase.ConsoleApp.Entities
{
    public class PostDetails
    {
        public string PostCode { get; set; }
        public DateTime PostDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public static IEnumerable<PostDetails> GetList()
        {
            return new List<PostDetails>()
            {
                new PostDetails()
                {
                    PostCode = "POST-123",
                    PostDate = new DateTime(2023, 11, 25),
                    Description = "This is the first post.",
                    Status = 1
                },
                new PostDetails()
                {
                    PostCode = "POST-456",
                    PostDate = new DateTime(2023, 12, 10),
                    Description = "A second post with more details.",
                    Status = 2
                },
                new PostDetails()
                {
                    PostCode = "POST-789",
                    PostDate = new DateTime(2024, 01, 15),
                    Description = "A short and sweet post.",
                    Status = 1
                },
                new PostDetails()
                {
                    PostCode = "POST-012",
                    PostDate = new DateTime(2024, 02, 20),
                    Description = "A longer post with multiple paragraphs.",
                    Status = 3
                },
                new PostDetails()
                {
                    PostCode = "POST-345",
                    PostDate = new DateTime(2024, 03, 25),
                    Description = "A post with an image and a link.",
                    Status = 2
                }
            };
        }
    }
}
