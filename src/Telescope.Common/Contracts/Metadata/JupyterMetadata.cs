using System.Text.Json.Serialization;

namespace Telescope.Common.Contracts.Metadata
{
    public class JupyterMetadata
    {
        /// <summary>
        /// Whether the cell's source should be shown
        /// </summary>
        [JsonPropertyName("source_hidden")]
        public bool SourceHidden { get; set; }

        /// <summary>
        /// Whether the cell's outputs should be shown
        /// </summary>
        [JsonPropertyName("output_hidden")]
        public bool OutputHidden { get; set; }
    }
}
