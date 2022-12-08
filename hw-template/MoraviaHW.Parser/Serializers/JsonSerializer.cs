using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using Newtonsoft.Json;

namespace MoraviaHW.Parser.Serializers;

public class JsonSerializer : JsonDocumentEvaluator, IDocumentSerializer
{
    /// <inheritdoc />
    public string Serialize(TitleTextDocument document)
    {
        return JsonConvert.SerializeObject(document, Formatting.Indented);
    }
}