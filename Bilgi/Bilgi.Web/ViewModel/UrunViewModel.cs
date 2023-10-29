﻿using Bilgi.Entity.Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bilgi.Web.ViewModel
{
    public class UrunViewModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool SatisDurum { get; set; }
        public bool SatisDurumu { get; set; }
        public string Marka { get; set; }
        public int Stok { get; set; }


        [Column(TypeName = "money")]
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public string ResimUrl1 { get; set; }
        public string ResimUrl2 { get; set; }
        public string ResimUrl3 { get; set; }
        public string ResimUrlKucuk { get; set; }
        public string ResimBaslik { get; set; }
        public int KategoriId { get; set; }

        public Kategori Kategori { get; set; }
        public IEnumerable<Ozellik> Ozellikler { get; set; }
    }
}
