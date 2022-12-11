using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser.Parsers
{
    public class ArgumentParser : IArgumentParser
    {
        private readonly IEnumerable<IStorageTypeEvaluator> _storageTypesEvaluator;

        public ArgumentParser(IEnumerable<IStorageTypeEvaluator> storageTypeEvaluators)
        {
            _storageTypesEvaluator = storageTypeEvaluators;
        }

        public string ParseInputFile()
        {
            Console.WriteLine("Enter input file route:");

            while (true)
            {
                var possibleInputFile = Console.ReadLine();
                if(_storageTypesEvaluator.FirstOrDefault(x => x.Evaluate(possibleInputFile)) != null)
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
