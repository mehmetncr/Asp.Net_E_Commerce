using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Entity.Layer.Entities
{
    public class SepetDetay
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
