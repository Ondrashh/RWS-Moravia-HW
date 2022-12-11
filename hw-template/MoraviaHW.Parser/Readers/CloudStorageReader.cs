using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.StorageTypeEvaluators;

namespace MoraviaHW.Parser.Readers
{
    public class CloudStorageReader : CloudStorageEvaluator, IDataReader
    {
        public async Task<string> ReadAsync(string filePath)
        {
            ArgumentCheck.IsNotNullOrWhiteSpace(filePath, nameof(filePath));
            var token = await Authenticate();
            return "{\n  \"Title\": \"Some title\",\n  \"Text\": \"Some text\"\n}";
        }
       
        private async Task<string> Authenticate()
        {
            await Task.Delay(2000);

            return "Token";
        }
    }
}
