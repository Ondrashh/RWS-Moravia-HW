using MoraviaHW.Parser.Models;

namespace MoraviaHW.Parser.Interfaces;

public interface IDocumentSerializer : IDocumentTypeEvaluator
{
    string Serialize(TitleTextDocument document);
}