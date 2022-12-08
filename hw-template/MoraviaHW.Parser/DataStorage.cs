using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser;

public class DataStorage : IDataStorage
{
    private readonly IEnumerable<IDataReader> _readers;
    private readonly IEnumerable<IDataWriter> _writers;

    public DataStorage(
        IEnumerable<IDataReader> readers,
        IEnumerable<IDataWriter> writers
    )
    {
        ArgumentCheck.IsNotNull(readers, nameof(readers));
        ArgumentCheck.IsNotNull(writers, nameof(writers));

        _readers = readers;
        _writers = writers;
    }

    public async Task<string> ReadAsync(string sourceFilePath)
    {
        ArgumentCheck.IsNotNullOrEmpty(sourceFilePath, nameof(sourceFilePath));

        var reader = GetReaderForFile(sourceFilePath);

        return await reader.ReadAsync(sourceFilePath);
    }

    public async Task WriteAsync(string targetFilePath, string data)
    {
        ArgumentCheck.IsNotNullOrEmpty(targetFilePath, nameof(targetFilePath));

        var writer = GetWriterForFile(targetFilePath);

        await writer.WriteAsync(targetFilePath, data);
    }

    private IDataReader GetReaderForFile(string sourceFilePath)
    {
        ArgumentCheck.IsNotNullOrEmpty(sourceFilePath, nameof(sourceFilePath));

        return _readers.FirstOrDefault(x => x.Evaluate(sourceFilePath));
    }

    private IDataWriter GetWriterForFile(string targetFilePath)
    {
        ArgumentCheck.IsNotNullOrEmpty(targetFilePath, nameof(targetFilePath));

        return _writers.FirstOrDefault(x => x.Evaluate(targetFilePath));
    }
}