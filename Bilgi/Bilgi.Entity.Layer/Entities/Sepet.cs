using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Entity.Layer.Entities
{
    public class Sepet
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public int MusteriId { get; set; }
        public int ToplamAdet { get; set; }

        [Column(TypeName = "money")]
        public decimal ToplamnTutar { get; set; }
        public List<SepetDetay> SepetDetaylari { get; set; }
    }
}
