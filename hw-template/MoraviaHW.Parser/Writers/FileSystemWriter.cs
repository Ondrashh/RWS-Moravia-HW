using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.StorageTypeEvaluators;

namespace MoraviaHW.Parser.Writers;

public class FileSystemWriter : FileSystemStorageEvaluator, IDataWriter
{
    /// <inheritdoc />
    public async Task WriteAsync(string filePath, string data)
    {
        // TODO: implement
        throw new NotImplementedException();
    }
}