using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.CustomHelpers
{
    public static class Eklenti
    {
        static public HtmlString Baslik(this IHtmlHelper helper,string baslik)
        {
            return new HtmlString("<h1>" + baslik +"</h1>");
        }

        static public HtmlString Liste(this IHtmlHelper helper, string[] liste)
        {
            string strHtml = "<ul>";
            foreach (string str in liste)
                strHtml += "<li>" + str + "</li>";
            strHtml += "</ul>";

            return new HtmlString(strHtml);
        }
    }
}
