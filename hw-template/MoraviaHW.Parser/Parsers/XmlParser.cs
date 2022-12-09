using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MoraviaHW.Parser.Parsers
{
    public class XmlParser : XmlDataTypeEvaluator, IDocumentParser
    {
        public TitleTextDocument Parse(string input)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Document";
            xRoot.IsNullable = false;

            XmlSerializer serializer = new XmlSerializer(typeof(TitleTextDocument), xRoot);
            using (StringReader sReader = new StringReader(input))
            {
                return (TitleTextDocument)serializer.Deserialize(sReader);
            }
        }
    }
}
