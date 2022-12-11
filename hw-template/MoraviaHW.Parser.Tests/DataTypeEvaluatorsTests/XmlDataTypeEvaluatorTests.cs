using MoraviaHW.Parser.DocumentTypeEvaluators;
using Xunit;

namespace MoraviaHW.Parser.Tests.DataTypeEvaluatorsTests
{
    public class XmlDataTypeEvaluatorTests
    {
        [Theory]
        [InlineData("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
            "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Title>Some title</Title>\r\n  " +
            "<Text>Some text</Text>\r\n</Document>")]
        [InlineData("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
            "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Title>sadasdasd title</Title>\r\n  " +
            "<Text>Some text</Text>\r\n</Document>")]
        public void Evaluate_CorrectXmlInput_ReturnsTrue(string data)
        {
            // Arrange
            var xmlEvaluator = new XmlDataTypeEvaluator();

            // Act
            var result = xmlEvaluator.Evaluate(data);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("fsadfdsfds")]
        [InlineData("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
        "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <</Title>\r\n  " +
        "<Text>Some text</Text>\r\n</Document>")]
        [InlineData("<?xml version=\"1.1\" encoding=\"utf-16\"?>\r\n<Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
        "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Title>sadasdasd title</Title>\r\n  " +
        "<Text>Some text</Text>")]
        public void Evaluate_WrongInput_ReturnsFalse(string data)
        {
            // Arrange
            var xmlEvaluator = new XmlDataTypeEvaluator();

            // Act
            var result = xmlEvaluator.Evaluate(data);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Evaluate_NullInput_ShouldThrowException()
        {
            // Arrange
            var xmlEvaluator = new XmlDataTypeEvaluator();
            string input = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => xmlEvaluator.Evaluate(input));
        }
    }
}
