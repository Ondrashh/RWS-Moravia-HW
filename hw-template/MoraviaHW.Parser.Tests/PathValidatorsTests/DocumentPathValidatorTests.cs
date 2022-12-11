using MoraviaHW.Parser.PathValidators;
using Xunit;

namespace MoraviaHW.Parser.Tests.PathValidatorsTests
{
    public class DocumentPathValidatorTests
    {
        [Fact]
        public void Validate_NullPath_ThrowsException()
        {
            // Arrange
            string path = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => DocumentPathValidator.Validate(path));
        }

        [Fact]
        public void Validate_WrongPath_ThrowsException()
        {
            // Arrange
            var path = "Wrong path";

            // Act
            // Assert
            Assert.Throws<FileNotFoundException>(() => DocumentPathValidator.Validate(path));
        }
    }
}