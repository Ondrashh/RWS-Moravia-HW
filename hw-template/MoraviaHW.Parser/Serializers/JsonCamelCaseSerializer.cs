using MoraviaHW.Parser.DocumentTypeEvaluators;
using MoraviaHW.Parser.Interfaces;
using MoraviaHW.Parser.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MoraviaHW.Parser.Serializers
{
    public class JsonCamelCaseSerializer : JsonCamelCaseDocumentEvaluator, IDocumentSerializer
    {
        public JsonCamelCaseSerializer(IOptions options) : base(options)
        {
        }

        public string Serialize(TitleTextDocument document)
        {
            ArgumentCheck.IsNotNull(document, nameof(document));
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };

            return JsonConvert.SerializeObject(document, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
        }
    }
}
