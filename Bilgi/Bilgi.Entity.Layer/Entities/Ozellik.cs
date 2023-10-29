using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Entity.Layer.Entities
{
    public  class Ozellik
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Urun Urun { get; set; }
    }
}
