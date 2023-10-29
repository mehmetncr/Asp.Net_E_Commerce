using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.Controllers.Main
{
    public class HakkimizdaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
