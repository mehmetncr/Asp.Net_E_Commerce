using AutoMapper;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Web.Extensions;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi.Web.ViewComponents.MainBilgisayarlar
{
    public class MainBilgisayarlarViewComponent : ViewComponent
    {
        
        private readonly IUrunService _urunService;
        private readonly IMapper _mapper;

        public MainBilgisayarlarViewComponent( IUrunService urunService, IMapper mapper)
        {
          
            _urunService = urunService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
    

            return View(_mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x=>x.KategoriId==1 || x.KategoriId == 3 || x.KategoriId == 8 && x.SatisDurum==true)));
        }
    }
}
