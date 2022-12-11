using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser.StorageTypeEvaluators;

public class HttpStorageEvaluator : IStorageTypeEvaluator
{
    /// <inheritdoc />
    public bool Evaluate(string filePath)
    {
        ArgumentCheck.IsNotNull(filePath, nameof(filePath));

        if (!Uri.IsWellFormedUriString(filePath, UriKind.Absolute))
        {
            return false;
        }

        // Parse the input URI
        Uri uri = new Uri(filePath);

        // Check if the URI scheme is "http" or "https"
        if (uri.Scheme == "http" || uri.Scheme == "https")
        {
            return true;
        }

        return false;
    }
}