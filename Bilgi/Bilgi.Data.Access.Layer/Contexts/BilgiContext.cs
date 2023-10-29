using Bilgi.Data.Access.Layer.Identity.Models;
using Bilgi.Entity.Layer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Data.Access.Layer.Contexts
{
    public class BilgiContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public BilgiContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Ozellik> Ozellikler { get; set; }
        public DbSet<SepetDetay> SepetDetaylari { get; set; }
        public DbSet<Sepet> Sepettler { get; set; }



    }

}
