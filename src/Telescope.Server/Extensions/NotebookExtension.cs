using System.Threading.Tasks;
using Telescope.Common.Contracts;
using Telescope.Server.Helpers;

namespace Telescope.Server.Extensions
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
