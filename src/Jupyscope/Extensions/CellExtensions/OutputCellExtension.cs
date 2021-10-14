using System;
using Jupyscope.Contracts.CellOutputs;
using Jupyscope.Helpers;
using Markdig;

namespace Jupyscope.Extensions.CellExtensions
{
    public static class OutputCellExtension
    {
        private static readonly MarkdownPipeline pipeline;

        static OutputCellExtension()
        {
            var htmlParsinHelper = new HTMLParsingHelper(imagesBlockedCallBack: ImagesBlockedCallBack);
            var pipelineBuilder = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseEmojiAndSmiley().UseYamlFrontMatter().UseMathematics();
            pipelineBuilder.Extensions.Add(htmlParsinHelper);
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
            var result = "";
            foreach (var data in dataCell.Data)
            {
                if (data.Key.StartsWith("image"))
                {
                    var imgSrc = getStringContent(data.Value);
                    if (string.IsNullOrEmpty(imgSrc))
                    {
                        continue;
                    }
                    if (data.Key.Contains("svg"))
                    {
                        result += imgSrc;
                    }
                    else if (data.Key.Contains("png"))
                    {
                        result += $"<img src=\" data:{data.Key};base64,{imgSrc}\" alt=\"Output image\"/>";
                    }
                }
                else if (data.Key == "text/html")
                {
                    result += getStringContent(data.Value);
                }
            }
            return result;
        }

        private static string convertErrorToHtml(ErrorOutput errCell)
        {
            return "";
        }

        private static string convertStreamToHtml(StreamOutput streamCell)
        {
            return "";
        }

        private static void ImagesBlockedCallBack()
        {
            // TODO handle blocked images callback
        }

        private static string getStringContent(object obj)
        {
            if (obj is System.Text.Json.JsonArray dataArr)
            {
                return string.Join("", dataArr);
            }
            if (obj is string dataStr)
            {
                return dataStr;
            }
            return string.Empty;
        }
    }
}
