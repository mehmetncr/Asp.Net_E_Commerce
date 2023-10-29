using System.ComponentModel.DataAnnotations;

namespace Bilgi.Web.ViewModel
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email Alanı Boş Bırakılamaz")]

		public string Email { get; set; }


		[Required(ErrorMessage = "Sifre Boş Bırakılamaz")]


		public string Sifre { get; set; }

		public bool BeniHatirla { get; set; }
		public string ReturnUrl { get; set; }
	}
}
