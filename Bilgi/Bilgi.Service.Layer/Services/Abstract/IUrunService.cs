using Bilgi.Entity.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Service.Layer.Services.Abstract
{
    public interface IUrunService : IGenericService<Urun>
    {
        List<string> Markalar(int kategıriId);
    }
}
