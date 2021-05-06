using System.Text.Json.Serialization;

namespace Jupyscope.Contracts.Metadata
{
    public class Author
    {
        /// <summary>
        /// The author's name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
