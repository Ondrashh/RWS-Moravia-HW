namespace MoraviaHW.Parser.Interfaces;

public interface IDocumentConverter
{
    Task ConvertAsync(string sourceFilePath, string targetFilePath);
}