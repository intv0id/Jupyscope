namespace Jupyscope.Contracts
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Jupyscope.Contracts.Cells;
    using Jupyscope.Contracts.Metadata;

    public class Notebook
    {
        [JsonPropertyName("metadata")]
        public NotebookMetadata Metadata { get; set; }

        [JsonPropertyName("nbformat")]
        public int NotebookFormat { get; set; }

        [JsonPropertyName("nbformat_minor")]
        public int NotebookFormatMinor { get; set; }

        [JsonPropertyName("cells")]
        public List<BaseCell> Cells { get; set; }
    }
}
