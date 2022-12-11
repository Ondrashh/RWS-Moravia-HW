namespace MoraviaHW.Parser.PathValidators
{
    public static class HttpPathValidator
    {
        public static async Task ValidateAsync(string path)
        {
            ArgumentCheck.IsNotNull(path, "path");
            using HttpClient client = new HttpClient();
            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync(path);
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException("Was not able to access site");
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Was not able to access site");
                throw new InvalidOperationException("Was not able to access site");

            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Something is wrong with address");
                throw new InvalidOperationException("Was not able to access site");
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Request was canceled");
                throw new InvalidOperationException("Was not able to access site");
            }
        }
    }
}