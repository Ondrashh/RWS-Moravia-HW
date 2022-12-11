using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.StorageTypeEvaluators;
using System.Security.Authentication;

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
            var auth = true;
            await Task.Delay(1000);
            if (auth == false)
            {
                throw new AuthenticationException("Was not able to authenticatae");
            }
            return "Token";
        }
    }
}