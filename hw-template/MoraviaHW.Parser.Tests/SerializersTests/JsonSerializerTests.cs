using Moq;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using MoraviaHW.Parser.Serializers;
using Xunit;

namespace MoraviaHW.Parser.Tests.SerializersTests
{
    public class JsonSerializerTests
    {
        [Fact]
        public void Serialize_CorrectInput_ReturnString()
        {
            // Arrange
            var mock = new Mock<IOptions>();
            mock.Setup(x => x.GetOption("")).Returns(true);
            var documentObject = new TitleTextDocument
            {
                Text = "Some text",
                Title = "Some title"
            };
            var resultCorrect = "{\r\n  \"Title\": \"Some title\",\r\n  \"Text\": \"Some text\"\r\n}";
            var jsonSerializer = new JsonSerializer(mock.Object);

            // Act
            var result = jsonSerializer.Serialize(documentObject);

            // Assert 
            Assert.Equal(resultCorrect, result);
        }

        [Fact]
        public void Serialize_NullInput_ThrowsException()
        {
            // Arrange
            var mock = new Mock<IOptions>();
            mock.Setup(x => x.GetOption("")).Returns(true);
            TitleTextDocument documentObject = null;
            var jsonSerializer = new JsonCamelCaseSerializer(mock.Object);

            // Act
            // Assert 
            Assert.Throws<ArgumentNullException>(() => jsonSerializer.Serialize(documentObject));
        }
    }
}
