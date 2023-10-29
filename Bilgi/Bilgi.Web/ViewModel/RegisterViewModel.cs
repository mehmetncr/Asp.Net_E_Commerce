using System.ComponentModel.DataAnnotations;

namespace Bilgi.Web.ViewModel
{
	public class RegisterViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "İsim Alanı Boş Bırakılamaz")]
		public string Isim { get; set; }
		[Required(ErrorMessage = "Soyisim Alanı Boş Bırakılamaz")]

		public string SoyIsim { get; set; }
		[Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Bırakılamaz")]

		public string KullaniciAdi { get; set; }
		[Required(ErrorMessage = "Telefon Alanı Boş Bırakılamaz")]

		public string TelefonNo { get; set; }
		[Required(ErrorMessage = "Email Alanı Boş Bırakılamaz")]
		[EmailAddress(ErrorMessage = "Email Formatı Uygun Değil")]

		public string Email { get; set; }
		[Required(ErrorMessage = "Sifre Boş Bırakılamaz")]
		public string Sifre { get; set; }
		[Required(ErrorMessage = "Sifre Onay Boş Bırakılamaz")]
		[Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]   // password ile karşılaştır
		public string SifreTekrar { get; set; }
	}
}
