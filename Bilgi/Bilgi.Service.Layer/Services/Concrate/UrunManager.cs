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
    public class UrunManager : GenericManager<Urun>, IUrunService
    {
        private readonly IUrun _urun;

        public UrunManager(IGeneric<Urun> generic, IUrun urun) : base(generic)
        {
            _urun = urun;
        }

        public List<string> Markalar(int kategıriId)
        {
            return _urun.MarkalarList(kategıriId);
        }
    }
}
