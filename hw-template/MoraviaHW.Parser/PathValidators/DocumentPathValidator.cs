
namespace MoraviaHW.Parser.PathValidators
{
    public static class DocumentPathValidator
    {
        public static void Validate(string path)
        {
            ArgumentCheck.IsNotNull(path, "path");
            if (!File.Exists(path))
            {
                throw new ArgumentException("B-ráško to neexistuje");
            }
        }
    }
}
