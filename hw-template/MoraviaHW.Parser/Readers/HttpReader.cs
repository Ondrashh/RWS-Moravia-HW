using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.PathValidators;
using MoraviaHW.Parser.StorageTypeEvaluators;

namespace MoraviaHW.Parser.Readers;

public class HttpReader : HttpStorageEvaluator, IDataReader
{
    /// <inheritdoc />
    public async Task<string> ReadAsync(string filePath)
    {

        using (var httpClient = new HttpClient())
        {
            ArgumentCheck.IsNotNullOrWhiteSpace(filePath, nameof(filePath));
            await HttpPathValidator.ValidateAsync(filePath);
            return await httpClient.GetStringAsync(filePath);
        }
    }
}