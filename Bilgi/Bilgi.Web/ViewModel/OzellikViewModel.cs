

using Bilgi.Entity.Layer.Entities;

namespace Bilgi.Web.ViewModel
{
    public class OzellikViewModel
    {

        public int Id { get; set; }
        public int UrunId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Urun Urun { get; set; }
    }
}
