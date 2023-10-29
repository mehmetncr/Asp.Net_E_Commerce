using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.Controllers.Accounts
{
    [Authorize]
    public class ProfilController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
