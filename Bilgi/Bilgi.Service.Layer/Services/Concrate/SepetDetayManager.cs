
using Bilgi.Entity.Layer.Entities;
using Bilgi.Entity.Layer.Iterfaces;
using Bilgi.Service.Layer.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Service.Layer.Services.Concrate
{
    public class SepetDetayManager : GenericManager<SepetDetay>, ISepetDetayService
    {
        public SepetDetayManager(IGeneric<SepetDetay> generic) : base(generic)
        {
        }

        public List<SepetDetay> SepeteEkle(List<SepetDetay> sepet, SepetDetay siparis)    //sepete ürün eklemek veya olan ürünün sayısını arttırmal için
        {
            if (sepet.Any(x=>x.UrunId==siparis.UrunId))
            {
                foreach (var item in sepet)
                {
                    if (item.UrunId==siparis.UrunId)
                    {
                        item.Adet += siparis.Adet;
                        item.ToplamTutar += siparis.Adet * item.BirimFiyat;
                    }
                }
            }
            else
            {
                siparis.ToplamTutar=siparis.Adet*siparis.BirimFiyat;
                sepet.Add(siparis);
            }
            return sepet;
        }


    }
}
