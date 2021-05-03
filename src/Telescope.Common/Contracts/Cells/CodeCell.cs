using Dahomey.Json.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telescope.Common.Contracts.CellOutputs;
using Telescope.Common.Contracts.Enums;

namespace Telescope.Common.Contracts.Cells
{
    [JsonDiscriminator(CellTypeNames.Code)]
    public class CodeCell : BaseCell
    {
        [JsonPropertyName("execution_count")]
        public int? ExecutionCount { get; set; }

        [JsonPropertyName("source")]
        public List<string> Source { get; set; }

        [JsonPropertyName("outputs")]
        public List<BaseCellOutput> Outputs { get; set; }
    }
}
