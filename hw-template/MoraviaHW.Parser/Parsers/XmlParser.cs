using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoraviaHW.Parser.Parsers
{
    public class XmlParser : JsonDocumentEvaluator, IDocumentParser
    {
        public TitleTextDocument Parse(string input)
        {
            throw new NotImplementedException();
        }
    }
}
