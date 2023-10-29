using AutoMapper;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.Controllers.Main
{
    public class UrunDetayController : Controller
    {

        private readonly IUrunService _urunService;
        private readonly IOzellikService _ozellikService;
        private readonly IMapper _mapper;

        public UrunDetayController(IUrunService urunService, IOzellikService ozellikService, IMapper mapper)
        {
            _urunService = urunService;
            _ozellikService = ozellikService;
            _mapper = mapper;
        }

        public IActionResult Index(int id)
        {
            DetayViewModel model = new DetayViewModel()
            {
                Urun = _mapper.Map<UrunViewModel>(_urunService.TGetByIdFiltre(x => x.Id == id)),
                Ozellikler = _mapper.Map<IEnumerable<OzellikViewModel>>(_ozellikService.TGetListAllFiltre(x => x.UrunId == id))
            };

            return View(model);
        }
    }
}
