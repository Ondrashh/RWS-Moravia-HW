using MoraviaHW.Parser.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MoraviaHW.Parser.StorageTypeEvaluators;

public class FileSystemStorageEvaluator : IStorageTypeEvaluator
{
    /// <inheritdoc />
    public bool Evaluate(string filePath)
    {
        if (Uri.TryCreate(filePath, UriKind.Absolute, out var file))
        {
            return file.IsFile;
        }
        return false;
    }
}