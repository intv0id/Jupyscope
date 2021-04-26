using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Metadata;

namespace Telescope.Common.Contracts.Cells
{
    class RawCell : AttachableCell
    {
        [JsonPropertyName("source")]
        public new string Source { get; set; }
    }
}
