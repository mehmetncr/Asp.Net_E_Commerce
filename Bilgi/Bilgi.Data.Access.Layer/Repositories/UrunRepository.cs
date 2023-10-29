using Bilgi.Data.Access.Layer.Contexts;
using Bilgi.Entity.Layer.Entities;
using Bilgi.Entity.Layer.Iterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Data.Access.Layer.Repositories
{
    public class UrunRepository : GenericRepository<Urun>, IUrun
    {
        public readonly BilgiContext _context;
        public UrunRepository(BilgiContext context) : base(context)
        {
            this._context = context;
        }

        public List<string> MarkalarList(int id)
        {
            return _context.Urunler.Where(x => x.KategoriId == id).Select(x => x.Marka).Distinct().ToList();
        }
    }
}
