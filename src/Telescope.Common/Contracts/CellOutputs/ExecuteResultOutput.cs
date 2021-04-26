using System.Text.Json.Serialization;

namespace Telescope.Common.Contracts.CellOutputs
{
    public class ExecuteResultOutput : DataOutput
    {
        [JsonPropertyName("execution_count")]
        public int ExecutionCount { get; set; }
    }
}
