using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Enums;

namespace Telescope.Common.Contracts.CellOutputs
{
    public class StreamOutput : BaseCellOutput
    {
        [JsonPropertyName("name")]
        public OutputStdType Name { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
