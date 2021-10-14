using System.Threading.Tasks;
using Jupyscope.Contracts;
using Jupyscope.Helpers;

namespace Jupyscope.Extensions
{
    public static class NotebookExtension
    {
        public static async Task<string> ToHtml(this Notebook notebook)
        {
            var htmlResult = await TemplateHelper2.RenderHtml(notebook);
            return htmlResult;
        }
    }
}
