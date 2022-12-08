namespace MoraviaHW.Parser.Interfaces;

public interface IDataStorage
{
    Task<string> ReadAsync(string sourceFilePath);

    Task WriteAsync(string targetFilePath, string data);
}