using Bilgi.Entity.Layer.Entities;

namespace Bilgi.Web.ViewModel
{
    public class SepetDetayViewModel
    {
        public int Id { get; set; }
        public int SepetId { get; set; }
        public int UrunId { get; set; }
        public decimal BirimFiyat { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }

        public Sepet Sepet { get; set; }
        public Urun Urun { get; set; }
    }
}
