using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using Newtonsoft.Json;

namespace MoraviaHW.Parser.Parsers;

public class JsonParser : JsonDataTypeEvaluator, IDocumentParser
{
    /// <inheritdoc />
    public TitleTextDocument Parse(string input)
    {
        ArgumentCheck.IsNotNullOrWhiteSpace(input, nameof(input));
        try
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();

            // Set the MissingMemberHandling property to Error
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            return JsonConvert.DeserializeObject<TitleTextDocument>(input, settings);
        }
        catch (JsonReaderException)
        {
            throw new InvalidDataException("Wrong format of json string!");
        }
        catch (JsonSerializationException)
        {
            throw new InvalidDataException($"Members of JSON are not the same!");
        }
    }
}