using System.Text.Json.Serialization;
using Telescope.Common.Contracts.Attachments;

namespace Telescope.Common.Contracts.Cells
{
    public class AttachableCell : BaseCell
    {
        [JsonPropertyName("attachment")]
        public Attachment Attachments { get; set; }
    }
}
