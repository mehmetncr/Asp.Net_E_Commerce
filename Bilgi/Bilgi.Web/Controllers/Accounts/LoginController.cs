using Bilgi.Data.Access.Layer.Identity.Models;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.Identity.Client;

namespace Bilgi.Web.Controllers.Accounts
{
    public class LoginController : Controller
    {
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);  //tüm kullanıcılarda e maile göre kayıt aranır
			if (user == null)
			{
				ModelState.AddModelError("", "Kayıtlı Kullanıcı Bulunamadı");   //kayıt null gelirse
				return View(model);	
			}
			var girisDeneme = await _signInManager.PasswordSignInAsync(user, model.Sifre, false, false); // kayıtlı kullanıcıya ait şifre kontrolü
			if (girisDeneme.Succeeded)
			{
				return Redirect(model.ReturnUrl ?? "/Anasayfa/Index");  //yönlendirilmiş ise o sayfaya değil ise ana sayfaya gider
			}
			else
			{
				ModelState.AddModelError("","Kullanıcı Adı veya Şifre Yanlış");
				return View(model);
			}
			
			
		}
		public async Task<IActionResult> Cikis()
		{
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Anasayfa");
		}
	}
}
