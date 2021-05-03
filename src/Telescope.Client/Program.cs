using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Telescope.Common.Contracts;
using Telescope.Common.Serializers;
using Telescope.Server.Extensions;
using Telescope.TestData;

namespace Telescope.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
#if DEBUG
            var notebookJsonString = Encoding.UTF8.GetString(Resources.neural_cue_combination);
            var notebook = TelescopeConverter.Deserialize<Notebook>(notebookJsonString);
            var htmlNotebook = await notebook.ToHtml();

            var tempFile = Path.Combine(Path.GetTempPath(), $"temp_{Guid.NewGuid()}.html");
            await File.WriteAllTextAsync(tempFile, htmlNotebook);
            Process.Start(@"cmd.exe ", $@"/c {tempFile}");
#else

#endif
        }
    }
}
