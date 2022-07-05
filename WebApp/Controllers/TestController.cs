using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    public class TestController : ControllerBase
    {
        //Querystring uzerinden  ...?api-version=1.0
        [MapToApiVersion("1.0")]
        public IActionResult Islem()
        {
            return Ok("Test  versiyon 1.0");
        }
        [MapToApiVersion("1.1")]
        public IActionResult Islem2()
        {
            return Ok("Test  versiyon 1.1");
        }
        [MapToApiVersion("2.0")]
        public IActionResult Islem3()
        {
            return Ok("Test  versiyon 2.0");
        }
    }

    //******************v{version:apiVersion}
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class DenemeController : ControllerBase
    {
        //URL üzerinden

        [MapToApiVersion("1.0")]
        public IActionResult Islem()
        {
            return Ok("Deneme  versiyon 1.0");
        }
        [MapToApiVersion("2.0")]
        public IActionResult Islem2()
        {
            return Ok("Deneme  versiyon 2.0");
        }
    }
}