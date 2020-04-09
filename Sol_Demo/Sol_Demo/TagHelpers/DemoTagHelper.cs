using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sol_Demo.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("my-tag")]
    public class DemoTagHelper : TagHelper
    {
        private readonly IHtmlHelper htmlHelper = null;

        private const string InputValueAttributeName = "input-value";
        private const string OutputValueAttributeName = "output-value";


        public DemoTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        // Always use Model Expression from getting value from Model Expression
        [HtmlAttributeName(InputValueAttributeName)]
        public ModelExpression InputValue { get; set; }

        [HtmlAttributeName(OutputValueAttributeName)]
        public ModelExpression OutputValue { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            var content = await htmlHelper?.PartialAsync("~/Views/Shared/_DemoPartialView.cshtml", this);

            output.Content.SetHtmlContent(content);

            //return base.ProcessAsync(context, output);
        }
    }
}
