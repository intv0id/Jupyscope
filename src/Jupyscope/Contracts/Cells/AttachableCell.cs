using System.Text.Json.Serialization;
using Jupyscope.Contracts.Attachments;

namespace Jupyscope.Contracts.Cells
{
    public class AttachableCell : BaseCell
    {
        [JsonPropertyName("attachment")]
        public Attachment Attachments { get; set; }
    }
}
