using System.Text.Json.Serialization;
using Jupyscope.Contracts.Enums;

namespace Jupyscope.Contracts.Metadata
{
    public class OutputMetadata
    {
        /// <summary>
        /// Whether the output should be isolated into an IFrame
        /// </summary>
        [JsonPropertyName("isolated")]
        public bool Isolated { get; set; }
    }
}