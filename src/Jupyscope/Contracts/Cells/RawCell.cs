using Dahomey.Json.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jupyscope.Contracts.Enums;

namespace Jupyscope.Contracts.Cells
{
    [JsonDiscriminator(CellTypeNames.Raw)]
    public class RawCell : AttachableCell
    {
        [JsonPropertyName("source")]
        public List<string> Source { get; set; }
    }
}
