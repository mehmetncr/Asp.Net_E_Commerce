using AutoMapper;
using Bilgi.Entity.Layer.Entities;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Bilgi.Web.Controllers.Admin
{
    public class UrunController : Controller
    {
        private readonly IUrunService _urunService;
        private readonly IMapper _mapper;

        public UrunController(IUrunService urunService, IMapper mapper)
        {
            _urunService = urunService;
            _mapper = mapper;
        }

        public IActionResult Urunler()
        {
           
            return View(_mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAll()));
        }
        [HttpGet]
        public IActionResult UrunGuncelle(int id)
        {
            
            return View(_mapper.Map<UrunViewModel>(_urunService.TGetById(id)));
        }
        [HttpPost]
        public IActionResult UrunGuncelle(UrunViewModel model, IFormFile formFileKucuk, IFormFile formFileResim1, IFormFile formFileResim2, IFormFile formFileresim3)
        {
            
            if (formFileKucuk!=null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFileKucuk.FileName);
                var stram = new FileStream(path, FileMode.Create);
                formFileKucuk.CopyTo(stram);
                model.ResimUrlKucuk = "/images/" + formFileKucuk.FileName;
            }
            else
            {
                model.ResimUrlKucuk = model.ResimUrlKucuk;
            }
            if (formFileResim1!=null)
            {
                var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFileResim1.FileName);
                var stram1 = new FileStream(path1, FileMode.Create);
                formFileResim1.CopyTo(stram1);
                model.ResimUrl1 = "/images/" + formFileResim1.FileName;
            }
            else
            {
                model.ResimUrl1 = model.ResimUrl1;

            }
            if (formFileResim2!=null)
            {
                var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFileResim2.FileName);
                var stram2 = new FileStream(path2, FileMode.Create);
                formFileResim2.CopyTo(stram2);
                model.ResimUrl2 = "/images/" + formFileResim2.FileName;
            }
            else
            {
                model.ResimUrl2 = model.ResimUrl2;
            }
            if (formFileresim3!=null)
            {
                var path3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFileresim3.FileName);
                var stram3 = new FileStream(path3, FileMode.Create);
                formFileresim3.CopyTo(stram3);
                model.ResimUrl3 = "/images/" + formFileresim3.FileName;
            }
            else
            {
                model.ResimUrl3 = model.ResimUrl3;

            }


            _urunService.Update(_mapper.Map<Urun>(model));


            return RedirectToAction("Urunler");
        }
        public void UrunDurumDegis(int id)
        {
            Urun urun = _urunService.TGetById(id);
            if (urun.SatisDurum==true)
            {
                urun.SatisDurum = false;
            }
            else
            {
                urun.SatisDurum = true;
            }
            _urunService.Update(urun);



        }
        public IActionResult ListeGuncelle()
        {
        
            return PartialView("_AdminUrunListesi", _mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAll()));


        }
        

    }
}
