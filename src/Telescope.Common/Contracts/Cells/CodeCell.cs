using Dahomey.Json.Attributes;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telescope.Common.Contracts.CellOutputs;
using Telescope.Common.Contracts.Enums;

namespace Telescope.Common.Contracts.Cells
{
    [JsonDiscriminator(CellTypeNames.Code)]
    class CodeCell : BaseCell
    {
        [JsonPropertyName("source")]
        public new string Source { get; set; }

        [JsonPropertyName("outputs")]
        public List<BaseCellOutput> Outputs { get; set; }
    }
}
