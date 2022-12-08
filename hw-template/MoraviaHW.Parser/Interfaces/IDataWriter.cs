namespace MoraviaHW.Parser.Interfaces;

public interface IDataWriter : IStorageTypeEvaluator
{
    Task WriteAsync(string filePath, string data);
}