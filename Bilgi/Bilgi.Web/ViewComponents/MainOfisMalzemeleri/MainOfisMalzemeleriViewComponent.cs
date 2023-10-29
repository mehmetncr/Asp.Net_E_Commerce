using AutoMapper;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.ViewComponents.MainOfisMalzemeleri
{
    public class MainOfisMalzemeleriViewComponent : ViewComponent
    {
        private readonly IUrunService _urunService;
 
        private readonly IMapper _mapper;

        public MainOfisMalzemeleriViewComponent(IUrunService urunService, IMapper mapper)
        {
            _urunService = urunService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {           

            return View(_mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x => x.KategoriId == 7 && x.SatisDurum == true)));
        }
    }
}
