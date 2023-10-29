using AutoMapper;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.ViewComponents.MainKirtasiye
{
    public class MainKirtasiyeViewComponent : ViewComponent
    {
      
        private readonly IUrunService _urunService;
        private readonly IMapper _mapper;

        public MainKirtasiyeViewComponent(IUrunService urunService, IMapper mapper)
        {
          
            _urunService = urunService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
           

            return View(_mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x=>x.KategoriId==6 && x.SatisDurum==true)));
        }
    }
}
