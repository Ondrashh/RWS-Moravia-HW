using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MoraviaHW.Parser.Serializers;

public class JsonSerializer : JsonDocumentEvaluator, IDocumentSerializer
{
    /// <inheritdoc />
    public string Serialize(TitleTextDocument document)
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        return JsonConvert.SerializeObject(document, Formatting.Indented, settings);
    }
}