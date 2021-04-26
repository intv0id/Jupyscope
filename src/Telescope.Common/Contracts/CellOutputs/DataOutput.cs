using System.Text.Json.Serialization;

namespace Telescope.Common.Contracts.CellOutputs
{
    public class DataOutput : BaseCellOutput
    {
        [JsonPropertyName("data")]
        public CellOutputData Data { get; set; }
    }
}
