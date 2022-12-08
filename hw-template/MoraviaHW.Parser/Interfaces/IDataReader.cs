namespace MoraviaHW.Parser.Interfaces;

public interface IDataReader : IStorageTypeEvaluator
{
    Task<string> ReadAsync(string filePath);
}