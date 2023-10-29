using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.Controllers.Main
{
    public class IletisimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
