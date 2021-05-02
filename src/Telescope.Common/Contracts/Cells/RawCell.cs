using Dahomey.Json.Attributes;
using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Enums;

namespace Telescope.Common.Contracts.Cells
{
    [JsonDiscriminator(CellTypeNames.Raw)]
    class RawCell : AttachableCell
    {
        [JsonPropertyName("source")]
        public new string Source { get; set; }
    }
}
