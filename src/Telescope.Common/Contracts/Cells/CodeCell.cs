using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telescope.Common.Contracts.CellOutputs;
using Telescope.Common.Contracts.Metadata;

namespace Telescope.Common.Contracts.Cells
{
    class CodeCell : BaseCell
    {
        [JsonPropertyName("source")]
        public new string Source { get; set; }

        [JsonPropertyName("outputs")]
        public List<BaseCellOutput> Outputs { get; set; }
    }
}
