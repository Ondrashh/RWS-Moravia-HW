namespace MoraviaHW.Parser.Interfaces;

public interface IArgumentParser
{
    string ParseInputFile();
    string ParseOutputFile();
    void ParseSerializeCamelCaseOption();
}

