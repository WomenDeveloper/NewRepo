using Microsoft.AspNetCore.Mvc;

using WebApp.Models;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            List<Product> urunler = new List<Product>() { 
            new Product{ ProductID=11, Name="Product 1", Price=23 },
            new Product{ ProductID=15, Name="Product 2", Price=45 }
            };

            Response.Cookies.Append("cerezos", "Data:1234");

            //HttpContext.Session.SetString("sakla", "Saklanmış Veri...");
            HttpContext.Session.SetString("sakla",JsonConvert.SerializeObject(urunler));

            ViewBag.Aktar = HttpContext.Session.GetString("sakla");
            return View();
        }

        public IActionResult SessionTest()
        {
            string str= HttpContext.Session.GetString("sakla");
            return Content(str);
        }

        public IActionResult Cerez()
        {
            string str = Request.Cookies["cerezos"].ToString();
            return Content(str);
        }
    }
}
