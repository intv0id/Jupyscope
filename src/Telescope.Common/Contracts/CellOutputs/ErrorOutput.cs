using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Telescope.Common.Contracts.CellOutputs
{
    public class ErrorOutput : BaseCellOutput
    {
        [JsonPropertyName("ename")]
        public string ErrorName { get; set; }

        [JsonPropertyName("evalue")]
        public string ErrorValue { get; set; }

        [JsonPropertyName("traceback")]
        public List<string> TraceBack { get; set; }
    }
}
