using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.Controllers.Main
{
    public class AnasayfaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
