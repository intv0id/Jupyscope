using Jupyscope.Contracts;
using Jupyscope.Contracts.Cells;
using Jupyscope.Extensions.CellExtensions;
using Microsoft.AspNetCore.Html;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jupyscope.Helpers
{
    public static class TemplateHelper2
    {
        public static async Task<string> RenderHtml(Notebook model)
        {
            return $"<div><table><tbody>{GetCellsContent(model.Cells)}</tbody></table></div>";
        }

        private static string GetCellsContent(List<BaseCell> cells)
        {
            string content = "";
            foreach(BaseCell cell in cells)
            {
                CodeCell codeCell = cell as CodeCell;
                string counter = codeCell != null ? "<p>[" + codeCell.ExecutionCount.ToString() + "]</p>" : "";
               
                content += $"<tr><td>{counter}</td><td>{new HtmlString(cell.ToHtml())}</td></tr>";
                if (codeCell != null)
                {
                  foreach(var outputCell in codeCell.Outputs)
                  {
                        content += $"<tr><td/><td>{new HtmlString(outputCell.ToHtml())}</td></tr>";
                  }
                }
            }
            return content;
        }
    }
}
