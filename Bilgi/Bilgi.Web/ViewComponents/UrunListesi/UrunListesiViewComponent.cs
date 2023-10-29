using AutoMapper;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.ViewComponents.UrunListesi
{
    public class UrunListesiViewComponent : ViewComponent
    {
        private readonly IUrunService _urunService;
        private readonly IMapper _mapper;

        public UrunListesiViewComponent(IUrunService urunService, IMapper mapper)
        {
            _urunService = urunService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int? id ,string? marka)
        {
            if (id!=null)
            {
                return View(_mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x => x.KategoriId == id && x.SatisDurum == true)));
            }
            return View(_mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x => x.KategoriId == id && x.SatisDurum == true)));
        }
    }
}
