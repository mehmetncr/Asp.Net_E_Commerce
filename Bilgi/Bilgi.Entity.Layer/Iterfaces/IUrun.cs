using Bilgi.Entity.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Entity.Layer.Iterfaces
{
    public interface IUrun : IGeneric<Urun>
    {
        List<string> MarkalarList(int id);
    }
}
