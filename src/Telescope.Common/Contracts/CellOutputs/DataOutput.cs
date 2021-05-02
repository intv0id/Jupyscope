using Dahomey.Json.Attributes;
using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Enums;

namespace Telescope.Common.Contracts.CellOutputs
{
    [JsonDiscriminator(OutputTypeNames.DisplayData)]
    public class DataOutput : BaseCellOutput
    {
        [JsonPropertyName("data")]
        public CellOutputData Data { get; set; }
    }
}
