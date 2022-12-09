using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser.StorageTypeEvaluators;

public class HttpStorageEvaluator : IStorageTypeEvaluator
{
    /// <inheritdoc />
    public bool Evaluate(string filePath)
    {
        return Uri.IsWellFormedUriString(filePath, UriKind.RelativeOrAbsolute);
    }
}