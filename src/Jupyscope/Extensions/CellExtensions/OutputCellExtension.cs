using Markdig;
using System;
using System.Collections.Generic;
using System.Linq;
using Jupyscope.Helpers;
using Jupyscope.Contracts.CellOutputs;
using Jupyscope.Contracts.Enums;

namespace Jupyscope.Extensions.CellExtensions
{
    public static class OutputCellExtension
    {
        private static readonly MarkdownPipeline pipeline;

        static OutputCellExtension()
        {
            //var htmlParsinHelper = new HTMLParsingHelper(imagesBlockedCallBack: ImagesBlockedCallBack);
            var pipelineBuilder = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseEmojiAndSmiley().UseYamlFrontMatter().UseMathematics();
            //pipelineBuilder.Extensions.Add(htmlParsinHelper);
            pipeline = pipelineBuilder.Build();
        }

        public static string ToHtml(this BaseCellOutput cell)
        {
            return cell switch
            {
                DataOutput dataCell => convertDataToHtml(dataCell), //execute_result are also dataOutput
                ErrorOutput errCell => convertErrorToHtml(errCell),
                StreamOutput streamCell => convertStreamToHtml(streamCell),
                _ => throw new NotSupportedException(),
            };
        }

        private static string convertDataToHtml(DataOutput dataCell)
        {
            return string.Join("", "");
        }
        private static string convertErrorToHtml(ErrorOutput errCell)
        {
            string errTitle = errCell.ErrorName + ": " + errCell.ErrorValue;
            string msg = String.Join("\n", errCell.TraceBack);
            return Markdown.ToHtml(errTitle+msg, pipeline);
            //return errTitle + msg;
        }
        private static string convertStreamToHtml(StreamOutput streamCell)
        {
            switch(streamCell.Name)
            {
                case OutputStdType.stdout:
                    return "stdout: " + streamCell.Text;
                    
                case OutputStdType.stderr:
                    return "stderr: " + streamCell.Text;
                    
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
