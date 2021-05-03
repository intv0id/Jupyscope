using Markdig;
using System;
using System.Collections.Generic;
using System.Linq;
using Telescope.Common.Contracts.Cells;
using Telescope.Server.Helpers;

namespace Telescope.Server.Extensions.CellExtensions
{
    public static class BaseCellExtension
    {
        private static readonly MarkdownPipeline pipeline;

        static BaseCellExtension()
        {
            var htmlParsinHelper = new HTMLParsingHelper(imagesBlockedCallBack: ImagesBlockedCallBack);
            var pipelineBuilder = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseEmojiAndSmiley().UseYamlFrontMatter().UseMathematics();
            pipelineBuilder.Extensions.Add(htmlParsinHelper);
            pipeline = pipelineBuilder.Build();

        }

        public static string ToHtml(this BaseCell cell)
        {
            return cell switch
            {
                CodeCell codeCell => convertCodeToHtml(codeCell),
                MarkdownCell mdCell => convertMarkdownToHtml(mdCell),
                RawCell rwCell => convertRawToHtml(rwCell),
                _ => throw new NotSupportedException(),
            };
        }

        private static string convertMarkdownToHtml(MarkdownCell mdCell)
        {
            string source = string.Join("", mdCell.Source);
            return Markdown.ToHtml(source, pipeline);
        }

        private static string convertCodeToHtml(CodeCell codeCell)
        {
            string source = string.Join("", codeCell.Source);
            string language = ""; //TODO handle langage
            return Markdown.ToHtml($"``` {language}\n{source}\n```", pipeline);
        }

        private static string convertRawToHtml(RawCell rawCell)
        {
            return string.Join("", rawCell.Source);
        }

        private static void ImagesBlockedCallBack()
        {
            // TODO handle blocked images callback
        }
    }
}
