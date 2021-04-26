using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Telescope.Common.Contracts.Cells
{
    class MarkdownCell : AttachableCell
    {
        [JsonPropertyName("source")]
        public new string Source { get; set; }
    }
}
