using MoraviaHW.Parser.Models;

namespace MoraviaHW.Parser.Interfaces;

public interface IDocumentParser : IDocumentTypeEvaluator
{
    TitleTextDocument Parse(string input);
}