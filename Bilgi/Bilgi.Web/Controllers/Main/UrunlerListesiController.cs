using AutoMapper;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bilgi.Web.Controllers.Main
{
    public class UrunlerListesiController : Controller
    {
        private readonly IUrunService _urunService;
        private readonly IMapper _mapper;

        public UrunlerListesiController(IUrunService urunService, IMapper mapper)
        {
            _urunService = urunService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index(int id, string[]? marka,int fiyat ,string? ara)
        {
            if (id!=0 && marka.Length==0 && fiyat ==0 && ara==null)  // sadece id gelirse
            {
                TempData["id"] = id;
                ViewBag.Markalar = _urunService.Markalar(id);


                return View(_mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x => x.KategoriId == id && x.SatisDurum == true)));
            }
            TempData["id"] = id;
            ViewBag.Markalar = _urunService.Markalar(id);
            ViewBag.filtremarka = marka;
            ViewBag.filtrefiyat = fiyat;

            if (marka.Length !=0 && fiyat==0)  // sadece marka seçilirse
            {
                List<UrunViewModel> model = new List<UrunViewModel>();
                foreach (var item in marka)
                {
                    var urunler = _mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x => x.Marka.Contains(item) && x.SatisDurum == true));
                    foreach (var urun in urunler)
                    {
                        model.Add(urun);    
                    }
                   
                }
                return View(model);
            }
            if (marka.Length != 0 && fiyat != 0) // marka ve fiyat aynı anda seçilirse
            {
                List<UrunViewModel> model = new List<UrunViewModel>();
                foreach (var item in marka)
                {
                    var urunler = _mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x => x.Marka.Contains(item) &&x.Fiyat<=fiyat && x.SatisDurum == true));
                    foreach (var urun in urunler)
                    {
                        model.Add(urun);
                    }

                }
                return View(model);
            }
            if (marka.Length == 0 && fiyat != 0)  // sadece fiyat seçilirse
            {    

                return View(_mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x=>x.KategoriId == id &&x.Fiyat <= fiyat && x.SatisDurum == true)));
            }
            if (ara!=null)
            {
                return View(_mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x=> x.Adi.ToLower().Contains(ara.ToLower()) && x.SatisDurum == true)));
            }

            return View(_mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x => x.KategoriId == id && x.SatisDurum == true)));


        }
        public IActionResult MarkaFiltre(string marka)
        {

            int id =Convert.ToInt32( TempData["id"]);
          
            return PartialView("_FiltreSonucPartialView", _mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x => x.KategoriId == id && x.SatisDurum == true && x.Marka == marka)));
        }
    }
}
