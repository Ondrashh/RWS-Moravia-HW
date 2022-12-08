using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoraviaHW.Parser.Serializers
{
    public class XmlSerializer : XmlDocumentEvaluator, IDocumentSerializer
    {
        public string Serialize(TitleTextDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
