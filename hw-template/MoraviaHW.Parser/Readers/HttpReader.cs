using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.StorageTypeEvaluators;

namespace MoraviaHW.Parser.Readers;

public class HttpReader : HttpStorageEvaluator, IDataReader
{
    /// <inheritdoc />
    public async Task<string> ReadAsync(string filePath)
    {
        // TODO: implement
        throw new NotImplementedException();
    }
}