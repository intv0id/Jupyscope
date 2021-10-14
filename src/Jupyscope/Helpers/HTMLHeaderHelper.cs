namespace Jupyscope.Helpers
{
    public static class HTMLHeaderHelper
    {
        public static readonly string Header = $@"<!DOCTYPE html><html><head>{mathFormatterScript}{codeHighlighterScript}</head><body>";

        public const string Footer = "</body></html>";

        private const string mathFormatterScript = "<link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/katex@0.13.18/dist/katex.min.css\" integrity=\"sha384-zTROYFVGOfTw7JV7KUu8udsvW2fx4lWOsCEDqhBreBwlHI4ioVRtmIvEThzJHGET\" crossorigin=\"anonymous\"><script defer src=\"https://cdn.jsdelivr.net/npm/katex@0.13.18/dist/katex.min.js\" integrity=\"sha384-GxNFqL3r9uRJQhR+47eDxuPoNE7yLftQM8LcxzgS4HT73tp970WS/wV5p8UzCOmb\" crossorigin=\"anonymous\"></script><script defer src=\"https://cdn.jsdelivr.net/npm/katex@0.13.18/dist/contrib/auto-render.min.js\" integrity=\"sha384-vZTG03m+2yp6N6BNi5iM4rW4oIwk5DfcNdFfxkk9ZWpDriOkXX8voJBFrAO7MpVl\" crossorigin=\"anonymous\" onload=\"renderMathInElement(document.body);\"></ script>";

        private const string codeHighlighterScript = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.2.0/languages/go.min.js\"></script><link rel=\"stylesheet\" href=\"https://unpkg.com/@highlightjs/cdn-assets@11.2.0/styles/default.min.css\"><script src=\"https://unpkg.com/@highlightjs/cdn-assets@11.2.0/highlight.min.js\"></script><script>hljs.highlightAll();</script>";
    }
}