using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;

namespace MoraviaHW.Parser;

public class DocumentConverter : IDocumentConverter
{
    private readonly IEnumerable<IDocumentParser> _parsers;
    private readonly IEnumerable<IDocumentSerializer> _serializers;
    private readonly IDataStorage _storage;

    public DocumentConverter(
        IEnumerable<IDocumentParser> parsers,
        IEnumerable<IDocumentSerializer> serializers,
        IDataStorage storage
    )
    {
        ArgumentCheck.IsNotNull(parsers, nameof(parsers));
        ArgumentCheck.IsNotNull(serializers, nameof(serializers));
        ArgumentCheck.IsNotNull(storage, nameof(storage));

        _parsers = parsers;
        _serializers = serializers;
        _storage = storage;
    }

    public async Task ConvertAsync(string sourceFilePath, string targetFilePath)
    {
        ArgumentCheck.IsNotNullOrEmpty(sourceFilePath, nameof(sourceFilePath));
        ArgumentCheck.IsNotNullOrEmpty(targetFilePath, nameof(targetFilePath));

        var sourceDocument = await GetDocument(sourceFilePath);
        if(sourceDocument != null)
        {
            var targetDocument = ConvertDocument(targetFilePath, sourceDocument);

            await _storage.WriteAsync(targetFilePath, targetDocument);
        }
    }

    private async Task<TitleTextDocument> GetDocument(string sourceFilePath)
    {
        var source = await _storage.ReadAsync(sourceFilePath);

        var parser = GetParserForFile(source);

        return parser.Parse(source);
    }

    private string ConvertDocument(string targetFilePath, TitleTextDocument sourceDocument)
    {
        var serializer = GetSerializerForFile(targetFilePath);

        return serializer.Serialize(sourceDocument);
    }

    private IDocumentParser GetParserForFile(string source)
    {
        var parser = _parsers.FirstOrDefault(x => x.Evaluate(source));
        if (parser == null)
        {
            throw new InvalidOperationException($"Parser for inputFile doesn't exist.");
        }

        return parser;
    }

    private IDocumentSerializer GetSerializerForFile(string targetFilePath)
    {
        var serializer = _serializers.FirstOrDefault(x => x.Evaluate(targetFilePath));
        if (serializer == null)
        {
            throw new InvalidOperationException($"Serializer for {targetFilePath} doesn't exist.");
        }

        return serializer;
    }
}