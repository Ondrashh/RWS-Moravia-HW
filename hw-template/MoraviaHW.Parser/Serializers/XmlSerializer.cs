using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using System.Xml.Serialization;

namespace MoraviaHW.Parser.Serializers
{
    public class XmlSerializer : XmlDocumentEvaluator, IDocumentSerializer
    {
        public string Serialize(TitleTextDocument document)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Document";
            xRoot.IsNullable = false;

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TitleTextDocument), xRoot);
            using (StringWriter sReader = new StringWriter())
            {
                serializer.Serialize(sReader, document);
                return sReader.ToString();
            }
        }
    }
}
