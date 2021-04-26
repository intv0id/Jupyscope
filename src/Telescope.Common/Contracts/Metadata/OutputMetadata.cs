using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Enums;

namespace Telescope.Common.Contracts.Metadata
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