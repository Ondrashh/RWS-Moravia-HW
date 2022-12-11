using MoraviaHW.Parser.StorageTypeEvaluators;
using Xunit;

namespace MoraviaHW.Parser.Tests.StorageTypeEvaluatorsTests
{
    public class HttpStorageEvaluatorTests
    {
        [Theory]
        [InlineData("http://amazon.test.com/sdasda.json")]
        [InlineData("https://amazon.test.com/sdasda.json")]
        public void Evaluate_CorrectInput_ReturnsTrue(string data)
        {
            // Arrange
            var httpStorageEvaluator = new HttpStorageEvaluator();

            // Act
            var result = httpStorageEvaluator.Evaluate(data);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("s4://amazon.test.com/sdasda.json")]
        [InlineData("s3://amazon.test.com/sdasda.json")]
        [InlineData(@"C:\Users\ondre\Desktop\RWS-Moravia-HW\hw-template\MoraviaHW\SourceFiles\Document1.xml")]
        [InlineData("")]
        [InlineData("           ")]
        public void Evaluate_WrongInput_ReturnsFalse(string data)
        {
            // Arrange
            var httpStorageEvaluator = new HttpStorageEvaluator();

            // Act
            var result = httpStorageEvaluator.Evaluate(data);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Evaluate_NullInput_ThrowsException()
        {
            var httpStorageEvaluator = new HttpStorageEvaluator();
            string data = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => httpStorageEvaluator.Evaluate(data));
        }
    }
}