namespace MoraviaHW.Parser.PathValidators
{
    public static class HttpPathValidator
    {
        public static async Task ValidateAsync(string path)
        {
            ArgumentCheck.IsNotNull(path, "path");
            using HttpClient client = new HttpClient();
            HttpResponseMessage response;
            response = await client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Asi to není ten file na webu.");

        }
    }
}
