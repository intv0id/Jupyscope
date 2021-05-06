using Dahomey.Json.Attributes;
using System.Text.Json.Serialization;
using Jupyscope.Contracts.Enums;

namespace Jupyscope.Contracts.CellOutputs
{
    [JsonDiscriminator(OutputTypeNames.Stream)]
    public class StreamOutput : BaseCellOutput
    {
        [JsonPropertyName("name")]
        public OutputStdType Name { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
