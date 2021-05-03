using Dahomey.Json.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Enums;

namespace Telescope.Common.Contracts.Cells
{
    [JsonDiscriminator(CellTypeNames.Markdown)]
    public class MarkdownCell : AttachableCell
    {
        [JsonPropertyName("source")]
        public List<string> Source { get; set; }
    }
}
