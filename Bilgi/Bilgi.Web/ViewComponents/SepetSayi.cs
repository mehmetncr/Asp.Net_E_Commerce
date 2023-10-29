using Bilgi.Web.Extensions;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.ViewComponents
{
    public class SepetSayi : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var sepet = HttpContext.Session.GetJson<List<SepetDetayViewModel>>("sepet") ?? new List<SepetDetayViewModel>();
           
            return View(sepet.Count());
        }
    }
}
