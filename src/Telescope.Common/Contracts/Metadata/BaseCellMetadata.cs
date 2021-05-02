using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Enums;

namespace Telescope.Common.Contracts.Metadata
{
    public class BaseCellMetadata
    {
        /// <summary>
        /// Whether the cell's output container should be collapsed
        /// </summary>
        [JsonPropertyName("collapsed")]
        public bool Collapsed { get; set; }

        /// <summary>
        /// Whether the cell's output is scrolled, unscrolled, or autoscrolled
        /// </summary>
        [JsonPropertyName("scrolled")]
        public bool Scrolled { get; set; }

        /// <summary>
        /// If False, prevent deletion of the cell
        /// </summary>
        [JsonPropertyName("deletable")]
        public bool Deletable { get; set; }

        /// <summary>
        /// If False, prevent editing of the cell (by definition, this also prevents deleting the cell)
        /// </summary>
        [JsonPropertyName("editable")]
        public bool Editable { get; set; }

        /// <summary>
        /// The mime-type of a :ref:`Raw NBConvert Cell <raw nbconvert cells>`
        /// </summary>
        [JsonPropertyName("format")]
        public MimeTypes MimeType { get; set; }

        /// <summary>
        /// A name for the cell. Should be unique across the notebook. Uniqueness must be verified outside of the json schema.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// A list of string tags on the cell. Commas are not allowed in a tag
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// A namespace holding jupyter specific fields. See docs below for more details
        /// </summary>
        [JsonPropertyName("jupyter")]
        public JupyterMetadata Jupyter { get; set; }

        /// <summary>
        /// A namespace holding execution specific fields. See docs below for more details
        /// </summary>
        [JsonPropertyName("execution")]
        public Dictionary<string, object> Execution { get; set; }
    }
}
