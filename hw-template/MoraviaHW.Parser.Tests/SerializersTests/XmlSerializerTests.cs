using Moq;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using MoraviaHW.Parser.Serializers;
using Xunit;

namespace MoraviaHW.Parser.Tests.SerializersTests
{
    public class XmlSerializerTests
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
            var resultCorrect = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
                " xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Title>Some title</Title>\r\n  <Text>Some text</Text>\r\n</Document>";
            var jsonCamelCaserSerializer = new XmlSerializer();

            // Act
            var result = jsonCamelCaserSerializer.Serialize(documentObject);

            // Assert
            Assert.Equal(resultCorrect, result);
        }

        [Fact]
        public void Serialize_NullInput_ThrowsException()
        {
            // Arrange
            TitleTextDocument documentObject = null;
            var xmlSerializer = new XmlSerializer();

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => xmlSerializer.Serialize(documentObject));
        }
    }
}