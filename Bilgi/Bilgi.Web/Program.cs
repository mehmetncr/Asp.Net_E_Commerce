using Bilgi.Data.Access.Layer.Contexts;
using Bilgi.Data.Access.Layer.Repositories;
using Bilgi.Entity.Layer.Entities;
using Bilgi.Entity.Layer.Iterfaces;
using Bilgi.Service.Layer.Services.Abstract;
using Bilgi.Service.Layer.Services.Concrate;
using Microsoft.EntityFrameworkCore;
using Bilgi.Service.Layer.Extensions;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Bilgi.Data.Access.Layer.Identity.Models;
using System;
using Microsoft.CodeAnalysis.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<BilgiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));


builder.Services.AddScopeExtensions();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{

	options.Password.RequireNonAlphanumeric = false;  //karakter istemesin
	options.Password.RequiredLength = 3;  //uzunluðu en az 3 karakter olsun
	options.Password.RequireUppercase = false; //büyük harf istemesin
	options.Password.RequireLowercase = false;  //Küçük harf istemesin
	options.Password.RequireDigit = false; //sayý istemesin
										   //options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";  sadece bunlar kabul edilsin
	options.User.RequireUniqueEmail = false; //e mail eþsisiz olmalý
	options.Lockout.MaxFailedAccessAttempts = 3;  //3 yanlýþ denemeden sonra giriþi altaki süre kadar durdur
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);  // üstteki sayý kadaryanlýþ giriþten sonra 1 dk giriþi engeller
}).AddEntityFrameworkStores<BilgiContext>();




builder.Services.ConfigureApplicationCookie(op =>
{
    op.LoginPath = new PathString("/Login/Index");   //giriþ için sayfaya yönlendir
    op.LogoutPath = new PathString("/Anasayfa/Index"); //çýkýþ olursa sayfya yönlendir
    op.ExpireTimeSpan = TimeSpan.FromMinutes(120); //cookie ömrü dk
                                                  //op.AccessDeniedPath = new PathString("yetisi yok sayfasý"); // yetkisi olmayinca yönlendirme
    op.SlidingExpiration = true; //üsstteki 120  dk dolmadan tekar login olursa tekrar süreyi baþa alýr
    op.Cookie = new CookieBuilder()
    {
        Name = "IdentityAppCookie", //cookie adý
        HttpOnly = true,  //sadece tarayýcýdan girilsin programlar yakalayamayacak

    };

});
















builder.Services.AddSession(
    options => options.IdleTimeout = TimeSpan.FromMinutes(120)  //session'larýn ömrünü uzatýyoruz (default 20 dk (oturum sona ermezse))
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Anasayfa}/{action=Index}/{id?}");

app.Run();
