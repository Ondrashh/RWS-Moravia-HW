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
        var sourceFilePath = Path.Combine(@"http://echo.jsontest.com/key/value/one/two");

        var targetFilePath = Path.Combine(@"C:\Users\ondre\Desktop\yo\C# Homework\hw-template\MoraviaHW\Target Files1\Document1.xml");

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