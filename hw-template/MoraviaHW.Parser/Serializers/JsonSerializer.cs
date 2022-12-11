using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using Newtonsoft.Json;

namespace MoraviaHW.Parser.Serializers;

public class JsonSerializer : JsonDocumentEvaluator, IDocumentSerializer
{
    public JsonSerializer(IOptions options) : base(options)
    {
    }

    /// <inheritdoc />
    public string Serialize(TitleTextDocument document)
    {
        ArgumentCheck.IsNotNull(document, nameof(document));

        return JsonConvert.SerializeObject(document, Formatting.Indented);
    }
}