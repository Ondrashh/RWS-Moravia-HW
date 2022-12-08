using Microsoft.Extensions.DependencyInjection;
using MoraviaHW.Parser;
using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Parsers;
using MoraviaHW.Parser.Readers;
using MoraviaHW.Parser.Serializers;
using MoraviaHW.Parser.StorageTypeEvaluators;
using MoraviaHW.Parser.Writers;

namespace MoraviaHW;

class Program
{
    static async Task Main()
    {
        // TODO: implement arguments parsing
        //var sourceFilePath = string.Empty;
        //var targetFilePath = string.Empty;


        //var sourceFilePath = Path.Combine("google.com/kokos/na/snehu");
        var sourceFilePath = Path.Combine(@"C:\Users\ondre\Desktop\RWS-Moravia-HW\hw-template\MoraviaHW\SourceFiles\Document1.json");

        var targetFilePath = Path.Combine(@"C:\Users\ondre\Desktop\RWS-Moravia-HW\hw-template\MoraviaHW\TargetFiles\Document1.json");

        var serviceProvider = ConfigureApplication();

        try
        {
            var documentConverter = serviceProvider.GetRequiredService<IDocumentConverter>();
            await documentConverter.ConvertAsync(sourceFilePath, targetFilePath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        Console.WriteLine("Done.");
        Console.ReadKey();
    }

    private static ServiceProvider ConfigureApplication()
    {
        var serviceProvider = new ServiceCollection()
            // Add Converter
            .AddTransient<IDocumentConverter, DocumentConverter>()

            // Add Storage
            .AddTransient<IDataStorage, DataStorage>()

            // Add Document type evaluators
            .AddTransient<IDocumentTypeEvaluator, JsonDocumentEvaluator>()

            // Add Parsers
            .AddTransient<IDocumentParser, JsonParser>()

            // Add Serializers
            .AddTransient<IDocumentSerializer, JsonSerializer>()

            // Add Storage type evaluators
            .AddTransient<IStorageTypeEvaluator, FileSystemStorageEvaluator>()
            .AddTransient<IStorageTypeEvaluator, HttpStorageEvaluator>()

            // Add Readers
            .AddTransient<IDataReader, FileSystemReader>()
            .AddTransient<IDataReader, HttpReader>()

            // Add Writers
            .AddTransient<IDataWriter, FileSystemWriter>()

            .BuildServiceProvider();

        return serviceProvider;
    }
}