using MoraviaHW.Parser.StorageTypeEvaluators;
using Xunit;

namespace MoraviaHW.Parser.Tests.StorageTypeEvaluatorsTests
{
    public class FileSystemtorageEvaluatorTests
    {

        [Fact]
        public void Evaluate_CorrectInput_ReturnsTrue()
        {
            // Arrange
            string correctPath = @"C:\Users\ondre\Desktop\RWS-Moravia-HW\hw-template\MoraviaHW\SourceFiles\Document1.xml";
            var fileSystemStorageEvaluator = new FileSystemStorageEvaluator();

            // Act
            var result = fileSystemStorageEvaluator.Evaluate(correctPath);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("s4://amazon.test.com/sdasda.json")]
        [InlineData("http://amazon.test.com/sdasda.json")]
        [InlineData("https://amazon.test.com/sdasda.json")]
        [InlineData("s3://amazon.test.com/sdasda.json")]
        [InlineData("")]
        [InlineData("           ")]
        public void Evaluate_WrongInput_ReturnsFalse(string data)
        {
            // Arrange
            var fileSystemStorageEvaluator = new FileSystemStorageEvaluator();

            // Act
            var result = fileSystemStorageEvaluator.Evaluate(data);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Evaluate_NullInput_ThrowsException()
        {
            // Arrange
            var fileSystemStorageEvaluator = new FileSystemStorageEvaluator();
            string input = null;

            // Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => fileSystemStorageEvaluator.Evaluate(input));
        }
    }
}
