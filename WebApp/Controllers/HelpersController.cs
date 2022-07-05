using Microsoft.AspNetCore.Mvc;


using WebApp.Models;

namespace WebApp.Controllers
{
    public class HelpersController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.Sehirler = new string[] {"Istanbul","Ankara","Izmir","Bursa" };



            return View();
        }

        public IActionResult Dene()
        {
            Product product = new Product { ProductID = 123, Name = "Product 1", Price = 34 };

            return View(product);
        }
    }
}
