using MoraviaHW.Parser.DocumentTypeEvaluators;
using Xunit;

namespace MoraviaHW.Parser.Tests.DocumentTypeEvaluatorsTests
{
    public class XmlDocumentTypeEvaluatorTests
    {
        [Theory]
        [InlineData(@"C:\Document1.xml")]
        [InlineData(@"C:\Users\Desktop\RWS-Moravia-HW\hw-template\MoraviaHW\SourceFiles\Test22222.xml")]
        [InlineData(@"F:\Test33.xml")]
        public void Evaluate_CorrectXmlDocument_ReturnsTrue(string data)
        {
            // Arrange
            var xmlDocumentEvaluator = new XmlDocumentEvaluator();

            // Act
            var result = xmlDocumentEvaluator.Evaluate(data);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(@"C:\Users\ondre\Desktop\RWS-Moravia-HW\hw-template\MoraviaHW\SourceFiles\Document1.json")]
        [InlineData(@"D:\Users\Test2.docx")]
        [InlineData(@"C:\MoraviaHW\SourceFiles\Documen22223.pdf")]
        public void Evaluate_IncorrectJsonDocument_ReturnsFalse(string data)
        {
            // Arrange
            var xmlDocumentEvaluator = new XmlDocumentEvaluator();

            // Act
            var result = xmlDocumentEvaluator.Evaluate(data);

            // Assert
            Assert.False(result);
        }
    }
}