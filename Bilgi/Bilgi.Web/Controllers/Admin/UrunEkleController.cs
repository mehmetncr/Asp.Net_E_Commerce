using AutoMapper;
using Bilgi.Entity.Layer.Entities;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.Controllers.Admin
{
    public class UrunEkleController : Controller
    {
        private readonly IUrunService _urunService;
        private readonly IMapper _mapper;
        private readonly IOzellikService _ozellikService;

        public UrunEkleController(IUrunService urunService, IMapper mapper, IOzellikService ozellikService)
        {
            _urunService = urunService;
            _mapper = mapper;
            _ozellikService = ozellikService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(UrunViewModel model, IFormFile formFileKucuk, IFormFile formFileResim1, IFormFile formFileResim2, IFormFile formFileresim3)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFileKucuk.FileName);
            var stram = new FileStream(path, FileMode.Create);
            formFileKucuk.CopyTo(stram);

            var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFileResim1.FileName);
            var stram1 = new FileStream(path1, FileMode.Create);
            formFileResim1.CopyTo(stram1);

            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFileResim2.FileName);
            var stram2 = new FileStream(path2, FileMode.Create);
            formFileResim2.CopyTo(stram2);

            var path3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFileresim3.FileName);
            var stram3 = new FileStream(path3, FileMode.Create);
            formFileresim3.CopyTo(stram3);


            model.ResimUrlKucuk = "/images/" + formFileKucuk.FileName;
            model.ResimUrl1 = "/images/" + formFileResim1.FileName;
            model.ResimUrl2 = "/images/" + formFileResim2.FileName;
            model.ResimUrl3 = "/images/" + formFileresim3.FileName;

            model.SatisDurum = true;

            _urunService.Insert(_mapper.Map<Urun>(model));


            return RedirectToAction("OzellikEkle");
        }

        //*********************************************************************************************

        [HttpGet]
        public IActionResult OzellikGuncelle(int id)
        {
            var urun = _urunService.TGetById(id);
            TempData["id"] = urun.Id;
            ViewBag.UrunAdi = urun.Adi;
            IEnumerable<Ozellik> ozellikler = _ozellikService.TGetListAllFiltre(x => x.UrunId == id);
            return View(_mapper.Map<IEnumerable<OzellikViewModel>>(ozellikler));
        }
        [HttpPost]
        public IActionResult OzellikGuncelle(string[] OzellikAdi, string[] OzellikDegeri)
        {
            int id = Convert.ToInt32(TempData["id"]);
            List<OzellikViewModel> ozellikler = new List<OzellikViewModel>();

            for (int i = 0; i < OzellikAdi.Length; i++)
            {
                OzellikViewModel model = new OzellikViewModel();

                model.Key = OzellikAdi[i];
                model.UrunId = id;

                if (i < OzellikDegeri.Length)
                {
                    model.Value = OzellikDegeri[i];
                }
                else
                {
                    model.Value = null; // Dizide olmayan bir değer için varsayılan değeri ayarlayın.
                }
                if (model.Key != null)
                {
                    ozellikler.Add(model);
                }

            }

            _ozellikService.OzelliklerEkle(_mapper.Map<IEnumerable<Ozellik>>(ozellikler));


            return RedirectToAction("Urunler", "Urun");
        }

        //*********************************************************************************************


        [HttpGet]
        public IActionResult OzellikEkle()
        {

            var urun = _urunService.TGetListAll().AsEnumerable().OrderByDescending(u => u.Id).FirstOrDefault();
            TempData["id"] = urun.Id;
            ViewBag.UrunAdi = urun.Adi;


            return View();
        }
        [HttpPost]
        public IActionResult OzellikEkle(string[] OzellikAdi, string[] OzellikDegeri)
        {
            int id = Convert.ToInt32(TempData["id"]);
            List<OzellikViewModel> ozellikler = new List<OzellikViewModel>();

            for (int i = 0; i < OzellikAdi.Length; i++)
            {
                OzellikViewModel model = new OzellikViewModel();

                model.Key = OzellikAdi[i];
                model.UrunId = id;

                if (i < OzellikDegeri.Length)
                {
                    model.Value = OzellikDegeri[i];
                }
                else
                {
                    model.Value = null; // Dizide olmayan bir değer için varsayılan değeri ayarlayın.
                }
                if (model.Key != null)
                {
                    ozellikler.Add(model);
                }

            }

            _ozellikService.OzelliklerEkle(_mapper.Map<IEnumerable<Ozellik>>(ozellikler));


            return RedirectToAction("Urunler", "Urun");
        }




    }
}
