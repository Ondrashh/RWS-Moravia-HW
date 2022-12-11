using MoraviaHW.Parser.StorageTypeEvaluators;
using Xunit;

namespace MoraviaHW.Parser.Tests.StorageTypeEvaluatorsTests
{
    public class CloudStorageEvaluatorTests
    {
        [Fact]
        public void Evaluate_CorrectInput_ReturnsTrue()
        {
            // Arrange
            string correctPath = "s3://amazon.test.com/sdasda.json";
            var cloudEvaluator = new CloudStorageEvaluator();

            // Act
            var result = cloudEvaluator.Evaluate(correctPath);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("s4://amazon.test.com/sdasda.json")]
        [InlineData("http://amazon.test.com/sdasda.json")]
        [InlineData("https://amazon.test.com/sdasda.json")]
        [InlineData(@"C:\Users\ondre\Desktop\RWS-Moravia-HW\hw-template\MoraviaHW\SourceFiles\Document1.xml")]
        [InlineData("")]
        [InlineData("           ")]
        public void Evaluate_WrongInput_ReturnsFalse(string data)
        {
            // Arrange
            var cloudEvaluator = new CloudStorageEvaluator();

            // Act
            var result = cloudEvaluator.Evaluate(data);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Evaluate_NullInput_ThrowsException()
        {
            // Arrange
            var cloudEvaluator = new CloudStorageEvaluator();
            string data = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => cloudEvaluator.Evaluate(data));
        }
    }
}