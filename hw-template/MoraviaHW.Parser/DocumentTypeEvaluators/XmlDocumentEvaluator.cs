using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser.DocumentTypeEvaluators;

public class XmlDocumentEvaluator : IDocumentTypeEvaluator
{
    /// <inheritdoc />
    public bool Evaluate(string filePath)
    {
        ArgumentCheck.IsNotNullOrEmpty(filePath, nameof(filePath));
        if (Path.GetExtension(filePath) == ".xml")
        {
            return true;
        }
        return false;
    }
}