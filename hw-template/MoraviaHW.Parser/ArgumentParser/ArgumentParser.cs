using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser.Parsers
{
    public class ArgumentParser : IArgumentParser
    { 

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
    }
}
