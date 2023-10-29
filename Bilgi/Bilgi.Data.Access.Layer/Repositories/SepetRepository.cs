using Bilgi.Data.Access.Layer.Contexts;
using Bilgi.Entity.Layer.Entities;
using Bilgi.Entity.Layer.Iterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Data.Access.Layer.Repositories
{
    public class SepetRepository : GenericRepository<Sepet>, ISepet
    {
        public SepetRepository(BilgiContext context) : base(context)
        {
        }
    }
}
