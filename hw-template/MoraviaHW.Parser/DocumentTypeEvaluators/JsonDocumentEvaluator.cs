using MoraviaHW.Parser.Enums;
using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser.DocumentTypeEvaluators;

public class JsonDocumentEvaluator : IDocumentTypeEvaluator
{
    private readonly IOptions _options;
    public JsonDocumentEvaluator(IOptions options)
    {
        _options = options;
    }

    /// <inheritdoc />
    public bool Evaluate(string filePath)
    {
        ArgumentCheck.IsNotNullOrWhiteSpace(filePath, nameof(filePath));
        if (Path.GetExtension(filePath) == ".json" && !_options.GetOption(SerializeOptionsTypes.JsonCamelCase))
        {
            return true;
        }
        return false;        
    }
}