using System.Threading.Tasks;
using Jupyscope.Contracts;
using Jupyscope.Helpers;

namespace Jupyscope.Extensions
{
    public static class NotebookExtension
    {
        private const string notebookTemplateName = "/Templates/Notebook.cshtml";

        public static async Task<string> ToHtml(this Notebook notebook)
        {
            var template = TemplateHelper.RazorCompiledItems[notebookTemplateName];
            var htmlResult = await TemplateHelper.RenderHtml(template, notebook);
            return htmlResult;
        }
    }
}
