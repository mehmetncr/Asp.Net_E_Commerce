using AutoMapper;
using Bilgi.Entity.Layer.Entities;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Web.Extensions;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bilgi.Web.Controllers.Main
{
    public class SepetController : Controller
    {
        private readonly IUrunService _urunService;
        private readonly ISepetDetayService _sepetDetayService;
        private readonly IMapper _mapper;
    
        List<SepetDetayViewModel> sepet;

        public SepetController(IUrunService urunService, ISepetDetayService sepetDetayService,IMapper mapper)
        {
            _urunService = urunService;
            _sepetDetayService = sepetDetayService;
            _mapper = mapper;           

        }

        public IActionResult Index()
        {
           
            sepet = SepetAl();
            decimal toplam = 0;
            foreach (var item in sepet)
            {
                toplam += item.ToplamTutar;
            }
            ViewBag.toplam = toplam.ToString("C");
            return View(sepet);
        }
        private List<SepetDetayViewModel> SepetAl()
        { 
            var sepet = HttpContext.Session.GetJson<List<SepetDetayViewModel>>("sepet") ?? new List<SepetDetayViewModel>();  //sepet varsa olan sepet yoksa yeni sepet oluşturularak verilir
            return sepet;
        }
      
        public IActionResult SepeteEkle(int id, int Adet)
        {
           
            var urun = _urunService.TGetByIdFiltre(x => x.Id == id && x.SatisDurum==true);  //id den ürün bulunur
            sepet = SepetAl();   //sepet alınır
            SepetDetay siparis = new SepetDetay();   //yeni detay oluşturulur ve içeriği doldurulur
            siparis.Urun = urun;
            siparis.UrunId = urun.Id;
            siparis.Adet = Adet;
            siparis.BirimFiyat = urun.Fiyat;
          
            sepet = _mapper.Map<List<SepetDetayViewModel>>( _sepetDetayService.SepeteEkle(_mapper.Map<List<SepetDetay>>(sepet), siparis)); //sepete yeni detay eklenir
            SepetKaydet(sepet);  //sepet kaydedilir
            return RedirectToAction("Index");  //sepet gösterilir


        }
        public void SepetKaydet(List<SepetDetayViewModel> sepet)
        {
            HttpContext.Session.SetJson("sepet",  (_mapper.Map<List<SepetDetay>>( sepet))); //sepet sessiona kaydedilir
        }
        public IActionResult SepettenSil(int id)
        {
            sepet = SepetAl(); // sepeti al
            sepet.RemoveAll(x => x.UrunId==id); //ürünü sepetten sil
            SepetKaydet(sepet);  //sepeti kaydet
            return RedirectToAction("Index");
        }
        public void AdetGuncelle(int id,int adet)
        {
            sepet = SepetAl();
          var urun = sepet.Find(x => x.UrunId==id);
            urun.ToplamTutar = adet * urun.BirimFiyat;
            urun.Adet=adet;

            SepetKaydet(sepet);
    

        }

        public IActionResult GuncelSepet()   //ajax ile sepeti güncellemek için
        {
            sepet = SepetAl();
            return PartialView("_SepetPartialView", sepet);
        }
        public IActionResult GuncelSepetSayisi()  //ajax ile sepet ürün sayısını güncellemek için
        {
            
            return ViewComponent("SepetSayi");
        }



    }
}
