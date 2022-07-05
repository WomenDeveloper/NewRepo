using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.CustomHelpers
{
    
    public class Mesaj:TagHelper
    {
        public string CoreMesaj { get; set; }
        public string CoreYaziRengi { get; set; }
        public string CoreZeminRengi { get; set; }
        public int CoreYaziBoyutu { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.TagName = "h1";
            output.Attributes.Add("style", "color:" + CoreYaziRengi + ";background-color:" + CoreZeminRengi + ";font-size:" + CoreYaziBoyutu + "px");
            output.Content.Append(CoreMesaj);
        }
    }
}
