using AutoMapper;
using Bilgi.Entity.Layer.Entities;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bilgi.Web.ViewComponents.DetayAside
{
    public class DetayAsideViewComponent : ViewComponent
    {
        private readonly IUrunService _urunService;
        private readonly IMapper _mapper;

        public DetayAsideViewComponent(IUrunService urunService, IMapper mapper)
        {
            _urunService = urunService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int id)
        {
            Random random = new Random();
            var urunler = _urunService.TGetListAllFiltre(x => x.KategoriId == id&&x.SatisDurum==true).ToList();

            int urunSayisi = urunler.Count();
            List<Urun> rastgeleUrunler = new List<Urun>();

            if (urunSayisi > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    int rastgeleIndex = random.Next(0, urunSayisi);
                    rastgeleUrunler.Add(urunler[rastgeleIndex]);
                    urunler.RemoveAt(rastgeleIndex);
                    urunSayisi--;
                }
            }
            else
            {
                rastgeleUrunler = urunler;
            }


            return View(_mapper.Map<IEnumerable<UrunViewModel>>(rastgeleUrunler));
        }
    }
}
