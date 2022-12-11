
using MoraviaHW.Parser.Models;
using MoraviaHW.Parser.Parsers;
using Xunit;
using FluentAssertions;

namespace MoraviaHW.Parser.Tests.ParsersTests
{
    public class JsonParserTests
    {
        [Theory]
        [InlineData("{\r\n  \"Title\": \"Title\",\r\n  \"Text\": \"Text\"\r\n}")]
        public void Parse_CorrectJsonData_ReturnTitleTextDocumentObject(string data)
        {
            // Arrange
            var correctObject = new TitleTextDocument
            {
                Title = "Title",
                Text = "Text"
            };
            var jsonParser = new JsonParser();

            // Act
            var result = jsonParser.Parse(data);

            // Assert
            result.Should().BeEquivalentTo(correctObject);
        }

        [Theory]
        [InlineData("sdasdasd")]
        [InlineData("{\r\n  \"Toootle\": \"Title\",\r\n  \"Text\": \"Text\"\r\n}")]
        public void Parse_WrongData_ThrowsException(string data)
        {
            // Arrange
            var jsonParser = new JsonParser();

            // Act
            // Assert
            Assert.Throws<InvalidDataException>(() => jsonParser.Parse(data));
        }

        [Theory]
        [InlineData("{\r\n \"Text\": \"Text\"\r\n}")]
        public void Parse_PartialData_ReturnObject(string data)
        {
            // Arrange
            var correctObject = new TitleTextDocument
            {
                Text = "Text"
            };
            var jsonParser = new JsonParser();

            // Act
            var result = jsonParser.Parse(data);

            // Assert
            result.Should().BeEquivalentTo(correctObject);
        }

        [Theory]
        [InlineData(null)]
        public void Parse_NullData_ThrowsException(string data)
        {
            // Arrange
            var jsonParser = new JsonParser();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => jsonParser.Parse(data));
        }
    }
}
