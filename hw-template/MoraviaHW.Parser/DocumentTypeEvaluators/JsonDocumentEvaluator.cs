using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser.DocumentTypeEvaluators;

public class JsonDocumentEvaluator : IDocumentTypeEvaluator
{
    /// <inheritdoc />
    public bool Evaluate(string filePath)
    {
        ArgumentCheck.IsNotNullOrWhiteSpace(filePath, nameof(filePath));
        if (Path.GetExtension(filePath) == ".json")
        {
            return true;
        }
        return false;        
    }
}