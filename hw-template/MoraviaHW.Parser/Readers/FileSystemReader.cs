using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.PathValidators;
using MoraviaHW.Parser.StorageTypeEvaluators;

namespace MoraviaHW.Parser.Readers;

public class FileSystemReader : FileSystemStorageEvaluator, IDataReader
{
    /// <inheritdoc />
    public Task<string> ReadAsync(string filePath)
    {
        ArgumentCheck.IsNotNullOrWhiteSpace(filePath, nameof(filePath));
        DocumentPathValidator.Validate(filePath);

        return File.ReadAllTextAsync(filePath);
    }
}