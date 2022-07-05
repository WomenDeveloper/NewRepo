using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApp.Models;

namespace WebApp.CustomHelpers
{
    
    public class ProductTagHelper:TagHelper
    {
        public Product Product { get; set; }
        public string ZeminRengi { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            string strHtml = "";
            if (Product != null)
            {
                strHtml = "<div style='background-color:" + ZeminRengi + ";width:120px;height:160px'>";

                strHtml += "<p>" + Product.ProductID + "</p>";
                strHtml += "<p>" + Product.Name + "</p>";
                strHtml += "<p>" + Product.Price + "</p>";

                strHtml += "<div>";
            }
            output.Content.SetHtmlContent(strHtml);
        }
    }
}
