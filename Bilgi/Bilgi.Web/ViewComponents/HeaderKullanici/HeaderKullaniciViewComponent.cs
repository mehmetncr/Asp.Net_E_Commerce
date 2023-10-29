using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.ViewComponents.HeaderKullanici
{
    public class HeaderKullaniciViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
