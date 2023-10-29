namespace Bilgi.Web.ViewModel
{
    public class DetayViewModel
    {
        public UrunViewModel Urun { get; set; }
        public IEnumerable<OzellikViewModel> Ozellikler { get; set; }
    }
}
