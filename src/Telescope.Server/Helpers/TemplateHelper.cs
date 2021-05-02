using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Telescope.Server.Helpers
{
    public static class TemplateHelper
    {
        public static readonly Dictionary<string, RazorCompiledItem> RazorCompiledItems;

        static TemplateHelper()
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            var viewAssembly = RelatedAssemblyAttribute.GetRelatedAssemblies(thisAssembly, false).Single();
            var razorCompiledItems = new RazorCompiledItemLoader().LoadItems(viewAssembly);

            RazorCompiledItems = new Dictionary<string, RazorCompiledItem>();
            foreach (var item in razorCompiledItems)
            {
                RazorCompiledItems.Add(item.Identifier, item);
            }
        }

        public static async Task<string> RenderHtml<TModel>(RazorCompiledItem razorCompiledItem, TModel model)
        {
            using var stringWriter = new StringWriter();
            var razorPage = GetRazorPage(razorCompiledItem, model, stringWriter);
            await razorPage.ExecuteAsync();
            return stringWriter.ToString();
        }

        private static RazorPage GetRazorPage<TModel>(RazorCompiledItem razorCompiledItem, TModel model, TextWriter textWriter)
        {
            var razorPage = (RazorPage<TModel>)Activator.CreateInstance(razorCompiledItem.Type);

            razorPage.ViewData = new ViewDataDictionary<TModel>(
                new EmptyModelMetadataProvider(),
                new ModelStateDictionary())
            {
                Model = model
            };

            razorPage.ViewContext = new ViewContext
            {
                Writer = textWriter
            };

            razorPage.HtmlEncoder = HtmlEncoder.Default;
            return razorPage;
        }
    }
}
