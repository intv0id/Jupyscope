using System.Threading.Tasks;
using Jupyscope.Contracts;
using Jupyscope.Helpers;

namespace Jupyscope.Extensions
{
    public static class NotebookExtension
    {
        public static string ToHtml(this Notebook notebook)
        {
            var htmlResult = TemplateHelper.RenderHtml(notebook);
            return htmlResult;
        }
    }
}
