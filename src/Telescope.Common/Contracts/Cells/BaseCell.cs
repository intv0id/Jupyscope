using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Metadata;

namespace Telescope.Common.Contracts.Cells
{
    public class BaseCell
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("cell_type")]
        public string Type { get; set; }

        [JsonPropertyName("metadata")]
        public BaseCellMetadata Metadata { get; set; }
    }
}
