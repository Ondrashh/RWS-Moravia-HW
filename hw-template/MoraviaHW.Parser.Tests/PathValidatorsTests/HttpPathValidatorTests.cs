
using MoraviaHW.Parser.PathValidators;
using Xunit;

namespace MoraviaHW.Parser.Tests.PathValidatorsTests
{
    public class HttpPathValidatorTests
    {
        [Fact]
        public async Task Validate_NullPath_ThrowsException()
        {
            // Arrange
            string path = null;

            // Act
            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => HttpPathValidator.ValidateAsync(path));
        }

        [Fact]
        public async Task Validate_CorrectPath_ReturnsTrueAsync()
        {
            // Arrange
            string path = @"http://echo.jsontest.com/key/value/one/two";

            // Act
            await HttpPathValidator.ValidateAsync(path);

            // Assert
            // Not needed
        }
    }
}
