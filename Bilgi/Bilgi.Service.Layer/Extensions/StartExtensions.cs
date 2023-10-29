using Bilgi.Data.Access.Layer.Identity.Models;
using Bilgi.Data.Access.Layer.Repositories;
using Bilgi.Entity.Layer.Entities;
using Bilgi.Entity.Layer.Iterfaces;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Service.Layer.Services.Concrate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Service.Layer.Extensions
{
    public static class StartExtensions
    {
        public static void AddScopeExtensions(this IServiceCollection services) 
        {
            services.AddScoped<IOzellikService, OzellikManager>();
            services.AddScoped<ISepetService, SepetManager>();
            services.AddScoped<ISepetDetayService, SepetDetayManager>();
            services.AddScoped<IUrunService, UrunManager>();

            services.AddScoped<IOzellik, OzellikRepository>();
            services.AddScoped<IUrun, UrunRepository>();
            services.AddScoped<ISepet, SepetRepository>();
            services.AddScoped<ISepetDetay, SepetDetayRepository>();
            services.AddScoped(typeof(IGeneric<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));





			

		}
    }
}
