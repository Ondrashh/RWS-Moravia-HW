
using FluentAssertions;
using MoraviaHW.Parser.Models;
using MoraviaHW.Parser.Parsers;
using Xunit;

namespace MoraviaHW.Parser.Tests.ParsersTests
{
    public class XmlParserTests
    {
        [Theory]
        [InlineData("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
            "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Title>Title</Title>\r\n" +
            "  <Text>Text</Text>\r\n</Document>")]
        public void Parse_CorrectXmlData_ReturnTitleTextDocumentObject(string data)
        {
            // Arrange
            var correctObject = new TitleTextDocument
            {
                Title = "Title",
                Text = "Text"
            };
            var xmlParser = new XmlParser();

            // Act
            var result = xmlParser.Parse(data);

            // Assert
            result.Should().BeEquivalentTo(correctObject);
        }

        [Theory]
        [InlineData("sdasdasd")]
        [InlineData("<?xml version=\"1.5555555555\" encoding=\"utf-16\"?>\r\n<Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
            " xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Title>Some title</Title>\r\n  <Text>Some text</Text>")]
        public void Parse_WrongData_ThrowsException(string data)
        {
            // Arrange
            var xmlParser = new XmlParser();

            // Act
            // Assert
            Assert.Throws<InvalidDataException>(() => xmlParser.Parse(data));
        }

        [Theory]
        [InlineData("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
            "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n" +
            " <Text>Text</Text>\r\n</Document>")]
        public void Parse_PartialData_ReturnObject(string data)
        {
            // Arrange
            var correctObject = new TitleTextDocument
            {
                Text = "Text"
            };
            var xmlParser = new XmlParser();

            // Act
            var result = xmlParser.Parse(data);

            // Assert
            result.Should().BeEquivalentTo(correctObject);
        }

        [Theory]
        [InlineData(null)]
        public void Parse_NullData_ThrowsException(string data)
        {
            // Arrange
            var xmlParser = new XmlParser();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => xmlParser.Parse(data));
        }
    }
}
