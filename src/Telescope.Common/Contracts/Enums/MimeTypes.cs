using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telescope.Common.Contracts.Enums
{
    public enum MimeTypes
    {
        JupyterWidgetState, // "application/vnd.jupyter.widget-state+json",
        JupyterWidgetView, // "application/vnd.jupyter.widget-view+json",
        Javascript, // "application/javascript",
        HTML, //"text/html",
        Markdown, // "text/markdown",
        SVG, // "image/svg+xml",
        Latex, // "text/latex",
        PNG, // "image/png",
        JPEG, // "image/jpeg",
        Plain, // "text/plain",
    }
}
