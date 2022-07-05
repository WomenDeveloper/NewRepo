using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.CustomHelpers
{
   
    public class YaziTagHelper:TagHelper
    {
        //Pascal Notation yaz
        //Kullanırken kebap-notation kullan
        //Pascal notation yazilir=>kebap notatio kullanılır...
        public string MesajMetni { get; set; }
        public string HareketYonu { get; set; }
        public string YaziRengi { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.TagName = "Marquee";
            output.Attributes.Add("direction", HareketYonu);
            output.Attributes.Add("style", "color:" + YaziRengi);
            output.Content.Append(MesajMetni);
        }
    }
}
