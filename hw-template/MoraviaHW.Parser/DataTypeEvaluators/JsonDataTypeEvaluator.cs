using MoraviaHW.Parser.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoraviaHW.Parser.DocumentTypeEvaluators;

public class JsonDataTypeEvaluator : IDataTypeEvaluator
{
    /// <inheritdoc />
    public bool Evaluate(string data)
    {
        ArgumentCheck.IsNotNull(data, "data");

        try
        {
            JObject.Parse(data);
            return true;
        }
        catch (JsonReaderException)
        {
            return false;
        }
    }
}