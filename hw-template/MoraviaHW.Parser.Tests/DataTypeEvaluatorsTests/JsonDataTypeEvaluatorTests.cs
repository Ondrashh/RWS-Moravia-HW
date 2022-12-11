using MoraviaHW.Parser.DocumentTypeEvaluators;
using Xunit;

namespace MoraviaHW.Parser.Tests.DataTypeEvaluatorsTests
{
    public class JsonDataTypeEvaluatorTests
    {
        [Theory]
        [InlineData("{\r\n  \"Title\": \"Some title\",\r\n  \"Text\": \"Some text\"\r\n}")]
        [InlineData("{\r\n  \"Title\": \"Some title\",\r\n  \"Text\": \"Some MOOOOOOOOOOOOOOOOOOOORE text\"\r\n}")]
        public void Evaluate_CorrectJsonInput_ReturnsTrue(string data)
        {
            // Arrange
            var jsonEvaluator = new JsonDataTypeEvaluator();

            // Act
            var result = jsonEvaluator.Evaluate(data);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("fsadfdsfds")]
        [InlineData("\"Title\": \"Some title\",\r\n  \"Text\": \"Some text\"\r\n}")]
        [InlineData("{\r\n  \"Title\": Some title\",\r\n  \"Text\": \"Some text\"\r\n}")]
        public void Evaluate_WrongInput_ReturnsFalse(string data)
        {
            // Arrange
            var jsonEvaluator = new JsonDataTypeEvaluator();

            // Act
            var result = jsonEvaluator.Evaluate(data);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Evaluate_NullInput_ShouldThrowException()
        {
            // Arrange
            var jsonEvaluator = new JsonDataTypeEvaluator();
            string input = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => jsonEvaluator.Evaluate(input));
        }
    }
}
