using MoraviaHW.Parser.Interfaces;
using System.Xml;
using System.Xml.Linq;

namespace MoraviaHW.Parser.DocumentTypeEvaluators;

public class XmlDataTypeEvaluator : IDataTypeEvaluator
{
    /// <inheritdoc />
    public bool Evaluate(string input)
    {
        ArgumentCheck.IsNotNull(input, "input");

        try
        {
            XDocument.Parse(input);
            return true;
        }
        catch (XmlException)
        {
            return false;
        }
    }
}