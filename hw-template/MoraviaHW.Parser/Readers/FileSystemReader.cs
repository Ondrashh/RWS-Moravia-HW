using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.PathValidators;
using MoraviaHW.Parser.StorageTypeEvaluators;

namespace MoraviaHW.Parser.Readers;

public class FileSystemReader : FileSystemStorageEvaluator, IDataReader
{
    /// <inheritdoc />
    public async Task<string> ReadAsync(string filePath)
    {
        ArgumentCheck.IsNotNullOrWhiteSpace(filePath, nameof(filePath));
        await HttpPathValidator.ValidateAsync(filePath);

        return await File.ReadAllTextAsync(filePath);
    }
}