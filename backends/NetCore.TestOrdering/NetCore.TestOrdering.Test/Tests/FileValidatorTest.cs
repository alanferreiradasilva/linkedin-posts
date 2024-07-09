using Shouldly;
using Xunit.Priority;

namespace NetCore.TestOrdering.Test.Tests
{
    public class TxtFileValidatorTest : BaseTestOrdering
    {
        private const string FilePath = "file.txt";

        [Fact]
        [Priority(1)]
        public void CreateFile()
        {
            using (var writer = new StreamWriter(FilePath))
            {
                writer.WriteLine("Xunit ordering test");
            }
            File.Exists(FilePath).ShouldBeTrue();
        }

        [Fact]
        [Priority(2)]
        public void EditFirstLineFile()
        {
            var lines = File.ReadAllLines(FilePath);
            lines[0] = "Xunit ordering test edited";
            File.WriteAllLines(FilePath, lines);
        }

        [Fact]
        [Priority(3)]
        public void VerifyFileEdit()
        {
            var firstLine = File.ReadLines(FilePath).First();
            firstLine.ShouldBe("Xunit ordering test edited");
        }

        [Fact]
        [Priority(4)]
        public void DeleteFile()
        {
            File.Exists(FilePath).ShouldBeTrue();
            File.Delete(FilePath);
        }

        [Fact]
        [Priority(5)]
        public void VerifyFileDeletion()
        {
            File.Exists(FilePath).ShouldBeFalse();
        }
    }
}
