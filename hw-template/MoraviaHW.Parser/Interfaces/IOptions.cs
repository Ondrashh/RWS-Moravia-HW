namespace MoraviaHW.Parser.Interfaces
{
    public interface IOptions
    {
        void SetOption(string key, bool value);

        bool GetOption(string key);
    }
}