using Moq;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using MoraviaHW.Parser.Serializers;
using Xunit;

namespace MoraviaHW.Parser.Tests.SerializersTests
{
    public class JsonCamelCaseSerializerTests
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
            var resultCorrect = "{\r\n  \"title\": \"Some title\",\r\n  \"text\": \"Some text\"\r\n}";
            var jsonCamelCaserSerializer = new JsonCamelCaseSerializer(mock.Object);

            // Act
            var result = jsonCamelCaserSerializer.Serialize(documentObject);

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
            var jsonCamelCaserSerializer = new JsonCamelCaseSerializer(mock.Object);

            // Act
            // Assert 
            Assert.Throws<ArgumentNullException>(() => jsonCamelCaserSerializer.Serialize(documentObject));
        }
    }
}
