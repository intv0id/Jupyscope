using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Telescope.Common.Contracts.Metadata
{
    public class NotebookMetadata
    {
        /// <summary>
        /// A :ref:`kernel specification <kernelspecs>`
        /// </summary>
        [JsonPropertyName("kernelspec")]
        public Dictionary<string, object> KernelSpec { get; set; }

        /// <summary>
        /// A list of authors of the document
        /// </summary>
        [JsonPropertyName("authors")]
        public List<Author> Authors { get; set; }
    }
}
