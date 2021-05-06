using Dahomey.Json.Attributes;
using System.Text.Json.Serialization;
using Jupyscope.Contracts.Enums;

namespace Jupyscope.Contracts.CellOutputs
{
    [JsonDiscriminator(OutputTypeNames.ExecuteResult)]
    public class ExecuteResultOutput : DataOutput
    {
        [JsonPropertyName("execution_count")]
        public int ExecutionCount { get; set; }
    }
}
