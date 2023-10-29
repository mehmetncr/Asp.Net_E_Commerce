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
	options.Password.RequiredLength = 3;  //uzunlu�u en az 3 karakter olsun
	options.Password.RequireUppercase = false; //b�y�k harf istemesin
	options.Password.RequireLowercase = false;  //K���k harf istemesin
	options.Password.RequireDigit = false; //say� istemesin
										   //options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";  sadece bunlar kabul edilsin
	options.User.RequireUniqueEmail = false; //e mail e�sisiz olmal�
	options.Lockout.MaxFailedAccessAttempts = 3;  //3 yanl�� denemeden sonra giri�i altaki s�re kadar durdur
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);  // �stteki say� kadaryanl�� giri�ten sonra 1 dk giri�i engeller
}).AddEntityFrameworkStores<BilgiContext>();




builder.Services.ConfigureApplicationCookie(op =>
{
    op.LoginPath = new PathString("/Login/Index");   //giri� i�in sayfaya y�nlendir
    op.LogoutPath = new PathString("/Anasayfa/Index"); //��k�� olursa sayfya y�nlendir
    op.ExpireTimeSpan = TimeSpan.FromMinutes(120); //cookie �mr� dk
                                                  //op.AccessDeniedPath = new PathString("yetisi yok sayfas�"); // yetkisi olmayinca y�nlendirme
    op.SlidingExpiration = true; //�sstteki 120  dk dolmadan tekar login olursa tekrar s�reyi ba�a al�r
    op.Cookie = new CookieBuilder()
    {
        Name = "IdentityAppCookie", //cookie ad�
        HttpOnly = true,  //sadece taray�c�dan girilsin programlar yakalayamayacak

    };

});
















builder.Services.AddSession(
    options => options.IdleTimeout = TimeSpan.FromMinutes(120)  //session'lar�n �mr�n� uzat�yoruz (default 20 dk (oturum sona ermezse))
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
