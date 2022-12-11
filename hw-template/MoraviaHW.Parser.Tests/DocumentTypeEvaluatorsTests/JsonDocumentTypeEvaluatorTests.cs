using Moq;
using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using Xunit;

namespace MoraviaHW.Parser.Tests.DocumentTypeEvaluatorsTests
{
    public class JsonDocumentTypeEvaluatorTests
    {
        [Theory]
        [InlineData(@"C:\Document1.json")]
        [InlineData(@"C:\Users\Desktop\RWS-Moravia-HW\hw-template\MoraviaHW\SourceFiles\Test22222.json")]
        [InlineData(@"F:\Test33.json")]
        public void Evaluate_CorrectJsonDocument_ReturnsTrue(string data)
        {
            // Arrange
            var mock = new Mock<IOptions>();
            mock.Setup(x => x.GetOption("")).Returns(false);

            var jsonDocumentEvaluator = new JsonDocumentEvaluator(mock.Object);

            // Act
            var result = jsonDocumentEvaluator.Evaluate(data);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(@"C:\Users\ondre\Desktop\RWS-Moravia-HW\hw-template\MoraviaHW\SourceFiles\Document1.xml")]
        [InlineData(@"D:\Users\Test2.docx")]
        [InlineData(@"C:\MoraviaHW\SourceFiles\Documen22223.pdf")]
        public void Evaluate_IncorrectJsonDocument_ReturnsFalse(string data)
        {
            // Arrange
            var mock = new Mock<IOptions>();
            mock.Setup(x => x.GetOption("")).Returns(false);
            var jsonDocumentEvaluator = new JsonDocumentEvaluator(mock.Object);

            // Act
            var result = jsonDocumentEvaluator.Evaluate(data);

            // Assert
            Assert.False(result);
        }
    }
}