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
    public class OzellikRepository : GenericRepository<Ozellik> , IOzellik
    {
        private readonly BilgiContext _context;
        public OzellikRepository(BilgiContext context) : base(context)
        {
            _context = context;
        }

        public void OzelliklerEkle(IEnumerable<Ozellik> model)
        {
            foreach (var item in model)
            {
                _context.Ozellikler.Add(item);
            }
            _context.SaveChanges();
        }
    }
}
