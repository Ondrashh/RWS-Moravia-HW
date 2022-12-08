using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using Newtonsoft.Json;

namespace MoraviaHW.Parser.Parsers;

public class JsonParser : JsonDocumentEvaluator, IDocumentParser
{
    /// <inheritdoc />
    public TitleTextDocument Parse(string input)
    {
        ArgumentCheck.IsNotNullOrEmpty(input, nameof(input));

        return JsonConvert.DeserializeObject<TitleTextDocument>(input);
    }
}