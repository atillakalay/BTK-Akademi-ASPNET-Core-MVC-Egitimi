using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace StoreApp.Infrastructe.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "products")]
    public class LastestProductTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;

        [HtmlAttributeName("number")]
        public int Number { get; set; }

        public LastestProductTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var div = new TagBuilder("div");
            div.AddCssClass("my-3");

            var h6 = new TagBuilder("h6");
            h6.AddCssClass("lead");

            var icon = new TagBuilder("i");
            icon.AddCssClass("fa fa-box text-secondary");

            h6.InnerHtml.AppendHtml(icon);
            h6.InnerHtml.AppendHtml(" Lastest Products");

            var ul = new TagBuilder("ul");
            var products = _manager.ProductService.GetLastestProducts(Number, false);
            foreach (var product in products)
            {
                var li = new TagBuilder("li");

                var a = new TagBuilder("a");
                a.Attributes["href"] = $"/product/get/{product.ProductId}";
                a.InnerHtml.Append(product.ProductName);

                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);
            }

            div.InnerHtml.AppendHtml(h6);
            div.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(div);
        }
    }
}
