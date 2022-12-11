using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using System.Xml.Serialization;

namespace MoraviaHW.Parser.Parsers
{
    public class XmlParser : XmlDataTypeEvaluator, IDocumentParser
    {
        public TitleTextDocument Parse(string input)
        {
            ArgumentCheck.IsNotNullOrWhiteSpace(input, nameof(input));

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Document";
            xRoot.IsNullable = false;

            XmlSerializer serializer = new XmlSerializer(typeof(TitleTextDocument), xRoot);
            using (StringReader sReader = new StringReader(input))
            {
                try
                {
                    return (TitleTextDocument)serializer.Deserialize(sReader);
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidDataException("There is an error in XML formatting");
                }
            }
        }
    }
}