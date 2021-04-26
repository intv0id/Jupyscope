using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Enums;
using Telescope.Common.Contracts.Metadata;

namespace Telescope.Common.Contracts.CellOutputs
{
    public class BaseCellOutput
    {
        [JsonPropertyName("output_type")]
        public OutputType Type { get; set; }

        [JsonPropertyName("metadata")]
        public OutputMetadata Metadata { get; set; }
    }
}
