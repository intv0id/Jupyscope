using Dahomey.Json.Attributes;
using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Enums;

namespace Telescope.Common.Contracts.CellOutputs
{
    [JsonDiscriminator(OutputTypeNames.ExecuteResult)]
    public class ExecuteResultOutput : DataOutput
    {
        [JsonPropertyName("execution_count")]
        public int ExecutionCount { get; set; }
    }
}
