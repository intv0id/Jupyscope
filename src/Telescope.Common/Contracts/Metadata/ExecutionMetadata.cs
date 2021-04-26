using System;
using System.Text.Json.Serialization;

namespace Telescope.Common.Contracts.Metadata
{
    class ExecutionMetadata
    {
        /// <summary>
        /// Indicates the time at which the kernel broadcasts an execute_input message. This represents the time when request for work was received by the kernel.
        /// </summary>
        [JsonPropertyName("iopub.execute_input")]
        public DateTime ExecuteInput { get; set; }

        /// <summary>
        /// Indicates the time at which the iopub channel's kernel status message is 'busy'. This represents the time when work was started by the kernel.
        /// </summary>
        [JsonPropertyName("iopub.status.busy")]
        public DateTime StatusBusy { get; set; }

        /// <summary>
        /// Indicates the time at which the shell channel's execute_reply status message was created. This represents the time when work was completed by the kernel.
        /// </summary>
        [JsonPropertyName("shell.execute_reply")]
        public DateTime ExecuteReply { get; set; }

        /// <summary>
        /// Indicates the time at which the iopub channel's kernel status message is 'idle'. This represents the time when the kernel is ready to accept new work.
        /// </summary>
        [JsonPropertyName("iopub.status.idle")]
        public DateTime StatusIdle { get; set; }
    }
}
