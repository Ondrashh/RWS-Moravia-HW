using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser.StorageTypeEvaluators;

public class FileSystemStorageEvaluator : IStorageTypeEvaluator
{
    /// <inheritdoc />
    public bool Evaluate(string filePath)
    {
        ArgumentCheck.IsNotNull(filePath, nameof(filePath));

        if (Uri.TryCreate(filePath, UriKind.Absolute, out var file))
        {
            return file.IsFile;
        }
        return false;
    }
}