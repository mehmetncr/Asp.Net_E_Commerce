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
    public class SepetManager : GenericManager<Sepet>, ISepetService
    {
        public SepetManager(IGeneric<Sepet> generic) : base(generic)
        {
        }
    }
}
