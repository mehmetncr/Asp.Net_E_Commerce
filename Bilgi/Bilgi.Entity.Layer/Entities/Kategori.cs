using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Entity.Layer.Entities
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Adi { get; set; }

        public List<Urun> Urunler { get; set; }
    }
}
