using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jupyscope.Contracts;
using Jupyscope.Extensions;
using Jupyscope.TestData;
using Jupyscope.Serializers;
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
