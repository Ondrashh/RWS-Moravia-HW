using MoraviaHW.Parser.Writers;
using Xunit;

namespace MoraviaHW.Parser.Tests.WriterTests
{
    public class WriterTests
    {
        [Fact]
        public async Task WriteAsync_CorrectPathAndDate_SavesAsync()
        {
            // Arrange
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.json");
            var data = "test";
            var fileSystemWriter = new FileSystemWriter();

            // Act
            await fileSystemWriter.WriteAsync(path, data);

            // Assert
            Assert.True(File.Exists(path));

            File.Delete(path);
            Assert.False(File.Exists(data));
        }

        [Fact]
        public async Task WriteAsync_NullPath_ThrowsException()
        {
            // Arrange
            string path = null;
            var data = "test";
            var fileSystemWriter = new FileSystemWriter();

            // Act
            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => fileSystemWriter.WriteAsync(path, data));
        }

        [Fact]
        public async Task WriteAsync_NullData_ThrowsException()
        {
            // Arrange
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.json");
            string data = null;
            var fileSystemWriter = new FileSystemWriter();

            // Act
            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => fileSystemWriter.WriteAsync(path, data));
        }
    }
}
