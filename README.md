# 🔭 Jupyscope

[![Tests][UnitTestBadgeImage]][UnitTestBadgeLink]
[![NuGet version (Jupyscope)][NugetBadgeImage]][NugetBadgeLink]

A Jupyter notebook viewer implemented in C#. It converts ipynb files to html.

## Get started 

### Build the pane preview

#### Prerequisites

* Install WiX and WiX extension for visual studio

#### Build

* Build the solution
* Build WiX project
* The produced executable is located in `Artifacts\Installer\x86\[Debug/Release]`.

### Use the Nuget Library

A use case is provided in the Jupyscope.Client project:

``` cs
using Jupyscope.Contracts;
using Jupyscope.Extensions;
using Jupyscope.Helpers;
using Jupyscope.Serializers;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Telescope.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Some ipynb file content
            var notebookJsonString = Encoding.UTF8.GetString(...);

            // Deserialize the notebook content
            var notebook = TelescopeConverter.Deserialize<Notebook>(notebookJsonString);

            // HTML ready to display notebook
            htmlNotebook = $"{HTMLHeaderHelper.Header}{notebook.ToHtml()}{HTMLHeaderHelper.Footer}";

            // Save the result
            var tempFile = Path.Combine(Path.GetTempPath(), $"temp_{Guid.NewGuid()}.html");
            await File.WriteAllTextAsync(tempFile, htmlNotebook);

            // Open a browser (Windows only)
            Process.Start(@"cmd.exe ", $@"/c {tempFile}");
        }
    }
}

```

## Dev resources

* [ipynb file format reference](https://nbformat.readthedocs.io/en/latest/format_description.html)
* [How to register a file preview handler](https://docs.microsoft.com/en-us/windows/win32/shell/how-to-register-a-preview-handler)

## External dependencies

* [PowerToys](https://github.com/microsoft/PowerToys)
* [Markdig](https://github.com/xoofx/markdig)
* [Katex](https://katex.org/)
* [Highlight.js](https://highlightjs.org/)

## Known limitations

* Only svg, png, and html cell outputs are supported.
* Math support is partial (`\begin{align}...\end{align}`, ...)
* Output attachments not supported
* Markdown local filesystem references not supported


[UnitTestBadgeLink]: https://github.com/intv0id/Telescope/actions/workflows/Tests.yml
[UnitTestBadgeImage]: https://github.com/intv0id/Telescope/actions/workflows/Tests.yml/badge.svg
[NugetBadgeLink]: https://www.nuget.org/packages/Jupyscope/
[NugetBadgeImage]: https://img.shields.io/nuget/v/Jupyscope.svg?style=flat
