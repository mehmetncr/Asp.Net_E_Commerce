using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.Controllers.Main
{
    public class HizmetlerimizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GuvenlikSistemleriHizmetleri()
        {
            return View();
        }
        public IActionResult FiberAltyapıHizmetleri()
        {
            return View();
        }
        public IActionResult YaziciTeknikServisHizmetleri()
        {
            return View();
        }
        public IActionResult BilgisayarTeknikServisHizmetleri()
        {
            return View();
        }
        public IActionResult NetworkDataKablolamaHizmetleri()
        {
            return View();
        }
        public IActionResult KartusTonerServisHizmetleri()
        {
            return View();
        }
    }
}
