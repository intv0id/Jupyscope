using Dahomey.Json.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jupyscope.Contracts.Enums;

namespace Jupyscope.Contracts.CellOutputs
{
    [JsonDiscriminator(OutputTypeNames.Error)]
    public class ErrorOutput : BaseCellOutput
    {
        [JsonPropertyName("ename")]
        public string ErrorName { get; set; }

        [JsonPropertyName("evalue")]
        public string ErrorValue { get; set; }

        [JsonPropertyName("traceback")]
        public List<string> TraceBack { get; set; }
    }
}
