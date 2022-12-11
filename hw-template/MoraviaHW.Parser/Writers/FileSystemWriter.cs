using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.StorageTypeEvaluators;
using System.Text;

namespace MoraviaHW.Parser.Writers;

public class FileSystemWriter : FileSystemStorageEvaluator, IDataWriter
{
    /// <inheritdoc />
    public Task WriteAsync(string filePath, string data)
    {
        ArgumentCheck.IsNotNullOrWhiteSpace(filePath, nameof(filePath));
        ArgumentCheck.IsNotNull(data, nameof(data));


        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
        byte[] encodedText = Encoding.Unicode.GetBytes(data);

        using var sourceStream =
            new FileStream(
                filePath,
                FileMode.Create, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true);

        return sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
    }
}