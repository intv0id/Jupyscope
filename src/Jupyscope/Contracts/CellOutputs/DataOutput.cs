using Dahomey.Json.Attributes;
using System.Text.Json.Serialization;
using Jupyscope.Contracts.Enums;

namespace Jupyscope.Contracts.CellOutputs
{
    [JsonDiscriminator(OutputTypeNames.DisplayData)]
    public class DataOutput : BaseCellOutput
    {
        [JsonPropertyName("data")]
        public CellOutputData Data { get; set; }
    }
}
