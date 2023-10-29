using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.Controllers.Admin
{
    public class BiladminController : Controller
    {
        public IActionResult admin()
        {
            return View();
        }
    }
}
