using System.Text.Json.Serialization;
using Jupyscope.Contracts.Enums;
using Jupyscope.Contracts.Metadata;

namespace Jupyscope.Contracts.CellOutputs
{
    public class BaseCellOutput
    {
        [JsonPropertyName("output_type")]
        public string Type { get; set; }

        [JsonPropertyName("metadata")]
        public OutputMetadata Metadata { get; set; }
    }
}
