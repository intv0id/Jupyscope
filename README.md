# 🔭 Jupyscope

[![Tests][UnitTestBadgeImage]][UnitTestBadgeLink]
[![NuGet version (Jupyscope)][NugetBadgeImage]][NugetBadgeLink]

A Jupyter notebook viewer implemented in C#. It converts ipynb files to html.

## Get started 

A use case is provided in the Jupyscope.Client project:

``` cs
// Some ipynb file content
var notebookJsonString = ...; 

// Deserialize the notebook content
var notebook = TelescopeConverter.Deserialize<Notebook>(notebookJsonString);

// HTML ready to display notebook
var htmlNotebook = $"{HTMLHeaderHelper.Header}{notebook.ToHtml()}{HTMLHeaderHelper.Footer}";
```

## Dev resources

* [ipynb file format reference](https://nbformat.readthedocs.io/en/latest/format_description.html)

## External dependencies

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
