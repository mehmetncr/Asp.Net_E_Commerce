using AutoMapper;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bilgi.Web.ViewComponents.MainYazıcılar
{
    public class MainYazıcılarViewComponent : ViewComponent
    {

        private readonly IUrunService _urunService;
        private readonly IMapper _mapper;

        public MainYazıcılarViewComponent( IUrunService urunService, IMapper mapper)
        {          
            _urunService = urunService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {       


            return View(_mapper.Map<IEnumerable<UrunViewModel>>(_urunService.TGetListAllFiltre(x=>x.KategoriId==4 && x.SatisDurum==true)));
        }
    }
}
