using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jupyscope.Client.Helpers;
using Jupyscope.Contracts;
using Jupyscope.Extensions;
using Jupyscope.Serializers;
using Jupyscope.TestData;

namespace Telescope.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var notebookJsonString = Encoding.UTF8.GetString(Resources.neural_cue_combination);
            var notebook = TelescopeConverter.Deserialize<Notebook>(notebookJsonString);
            var htmlNotebook = await notebook.ToHtml();
            htmlNotebook = HTMLHeaderHelper.Header + htmlNotebook;
            var tempFile = Path.Combine(Path.GetTempPath(), $"temp_{Guid.NewGuid()}.html");
            await File.WriteAllTextAsync(tempFile, htmlNotebook);
            Process.Start(@"cmd.exe ", $@"/c {tempFile}");
        }
    }
}
