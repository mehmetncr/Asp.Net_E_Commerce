using AutoMapper;
using Bilgi.Entity.Layer.Entities;
using Bilgi.Web.ViewModel;

namespace Bilgi.Web.Mapping
{
    public class MappingPrpfile : Profile
    {
        public MappingPrpfile() 
        {
            CreateMap<Urun,UrunViewModel>().ReverseMap();
            CreateMap<Ozellik,OzellikViewModel>().ReverseMap();
            CreateMap<SepetDetay,SepetDetayViewModel>().ReverseMap();
         
        }
    }
}
