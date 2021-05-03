using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telescope.Common.Contracts;
using Telescope.Server.Extensions;
using Telescope.TestData;
using Telescope.Common.Serializers;
using System.Threading.Tasks;
using System.Text;

namespace Telescope.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public async Task Load_and_render_notebook()
        {
            var notebookJsonString = Encoding.UTF8.GetString(Resources.neural_cue_combination);
            var notebook = TelescopeConverter.Deserialize<Notebook>(notebookJsonString);
            _ = await notebook.ToHtml();
        }
    }

}
