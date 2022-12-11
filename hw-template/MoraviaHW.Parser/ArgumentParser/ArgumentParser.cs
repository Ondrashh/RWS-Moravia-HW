using MoraviaHW.Parser.Enums;
using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser.Parsers
{
    public class ArgumentParser : IArgumentParser
    { 
        private readonly IOptions _options;

        public ArgumentParser(IOptions options)
        {
            _options = options;
        }

        public string ParseInputFile()
        {
            Console.WriteLine("Enter input file route:");

            while (true)
            {
                var possibleInputFile = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(possibleInputFile))
                {
                    return possibleInputFile;
                }
                else
                {
                    Console.WriteLine("Enter valid input file!");
                }
            }
        }

        public string ParseOutputFile()
        {
            Console.WriteLine("Enter target file route:");

            while (true)
            {
                var possibleOutputFile = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(possibleOutputFile))
                {
                    return possibleOutputFile;
                }
                else{
                    Console.WriteLine("Enter valid target file route!");
                }
            }
        }

        public void ParseSerializeCamelCaseOption()
        {
            Console.WriteLine("If you want to save Json in camel case type 'yes' otherwise type 'no':");

            while (true)
            {
                var possibleOutputFile = Console.ReadLine();
                if (possibleOutputFile == "yes")
                {
                    _options.SetOption(SerializeOptionsTypes.JsonCamelCase, true);
                    break;
                }else if (possibleOutputFile == "no")
                {
                    break;
                }
            }
        }
    }
}
