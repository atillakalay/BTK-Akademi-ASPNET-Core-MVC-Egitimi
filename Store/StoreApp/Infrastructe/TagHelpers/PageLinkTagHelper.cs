using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.Models;

namespace StoreApp.Infrastructe.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }

        public Pagination PageModel { get; set; }
        public string? PageAction { get; set; }

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } = "";
        public string PageClassNormal { get; set; } = "";
        public string PageClassSelected { get; set; } = "";

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory) => _urlHelperFactory = urlHelperFactory;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext is null || PageModel is null) return;

            var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            var result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { PageNumber = i });
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrenPage ? PageClassSelected : PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
