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
    public class OzellikManager : GenericManager<Ozellik>, IOzellikService
    {
        private readonly IOzellik _ozellik;
        public OzellikManager(IGeneric<Ozellik> generic, IOzellik ozellik) : base(generic)
        {
            _ozellik = ozellik;
        }

        public void OzelliklerEkle(IEnumerable<Ozellik> model)
        {
            _ozellik.OzelliklerEkle(model);
        }
    }
}
