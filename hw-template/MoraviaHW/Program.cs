using Microsoft.Extensions.Configuration;
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
        var serviceProvider = ConfigureApplication();

        var argumentParser = serviceProvider.GetRequiredService<IArgumentParser>();

        var sourceFilePath = argumentParser.ParseInputFile(); 
        var targetFilePath = argumentParser.ParseOutputFile();

        var documentConverter = serviceProvider.GetRequiredService<IDocumentConverter>();

        await documentConverter.ConvertAsync(sourceFilePath, targetFilePath);

        Console.WriteLine("Done.");
        Console.ReadKey();
    }

    private static ServiceProvider ConfigureApplication()
    {
        var serviceProvider = new ServiceCollection()
            // Add parser
            .AddTransient<IArgumentParser, ArgumentParser>()

            // Add Converter
            .AddTransient<IDocumentConverter, DocumentConverter>()

            // Add Storage
            .AddTransient<IDataStorage, DataStorage>()

            // Add Document type evaluators
            .AddTransient<IDocumentTypeEvaluator, JsonDocumentEvaluator>()
            .AddTransient<IDocumentTypeEvaluator, XmlDocumentEvaluator>()

            // Add Data type evaluators
            .AddTransient<IDataTypeEvaluator, JsonDataTypeEvaluator>()
            .AddTransient<IDataTypeEvaluator, XmlDataTypeEvaluator>()

            // Add Parsers
            .AddTransient<IDocumentParser, JsonParser>()
            .AddTransient<IDocumentParser, XmlParser>()


            // Add Serializers
            .AddTransient<IDocumentSerializer, JsonSerializer>()
            .AddTransient<IDocumentSerializer, XmlSerializer>()


            // Add Storage type evaluators
            .AddTransient<IStorageTypeEvaluator, FileSystemStorageEvaluator>()
            .AddTransient<IStorageTypeEvaluator, CloudStorageEvaluator>()
            .AddTransient<IStorageTypeEvaluator, HttpStorageEvaluator>()

            // Add Readers
            .AddTransient<IDataReader, FileSystemReader>()
            .AddTransient<IDataReader, HttpReader>()
            .AddTransient<IDataReader, CloudStorageReader>()


            // Add Writers
            .AddTransient<IDataWriter, FileSystemWriter>()

            .BuildServiceProvider();

        return serviceProvider;
    }
}