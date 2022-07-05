using Microsoft.AspNetCore.Mvc;

using WebApp.Models;

namespace WebApp.Controllers
{
    public class YasamController : Controller
    {
        IEntity<Product> _product;
        Manager _manager;

        //ctor Injection
        public YasamController(IEntity<Product> product,Manager manager)
        {
            _product = product;
            _manager = manager;
        }

        public IActionResult Index()
        {

            ViewBag.Product = _product.ToString();
            ViewBag.Manager = _manager.Product.ToString();
            return View();
        }
    }
}
