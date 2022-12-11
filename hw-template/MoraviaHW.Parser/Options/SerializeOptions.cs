using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser.Options
{
    public class SerializeOptions : IOptions
    {
       private Dictionary<string, bool> openWith = new Dictionary<string, bool>();

        public bool GetOption(string key)
        {
            if(openWith.TryGetValue(key, out bool value))
            {
                return value;
            }
            return false;
        }

        public void SetOption(string key, bool value)
        {
            openWith[key] = value;
        }
    }
}
