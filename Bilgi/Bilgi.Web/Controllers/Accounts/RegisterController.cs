using Bilgi.Data.Access.Layer.Identity.Models;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.Controllers.Accounts
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public IActionResult Index()
		{
			return View();
		}
			[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Index(RegisterViewModel model)
		{
			var user = new AppUser()
			{
				Email=model.Email,
				Isim = model.Isim,
				SoyIsim = model.SoyIsim,
				PhoneNumber  = model.TelefonNo,
				
				
			};
			var kayitsonuc = await _userManager.CreateAsync(user , model.Sifre);
			if (kayitsonuc.Succeeded)
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				foreach (var error in kayitsonuc.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View();
			}
			return View();
		}
	}
}
