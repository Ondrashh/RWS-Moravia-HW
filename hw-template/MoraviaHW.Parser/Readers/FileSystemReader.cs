using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.StorageTypeEvaluators;

namespace MoraviaHW.Parser.Readers;

public class FileSystemReader : FileSystemStorageEvaluator, IDataReader
{
    /// <inheritdoc />
    public async Task<string> ReadAsync(string filePath)
    {
        // TODO: implement
        throw new NotImplementedException();
    }
}