using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrate;
using Cental.BusinessLayer.Extensions;
using Cental.BusinessLayer.Validaters;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// about service gördüðün zaman aboutmanager sýnýfýndan bir nesne örneði al ve iþlemi onunla yap .
builder.Services.AddDbContext<CentalContext>();
builder.Services.AddIdentity<AppUser, AppRole>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<CentalContext>().AddErrorDescriber<CustomErrorDescriber>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());




builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddValidatorsFromAssemblyContaining<BrandValidater>();
builder.Services.AddServiceRegistrations();





builder.Services.AddControllersWithViews(option=>
{
    option.Filters.Add(new AuthorizeFilter());
});

builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Login/Index"; // giriþ yolu
    cfg.LogoutPath = "/Login/Logout"; // çýkýþ yolu
    //cfg.Cookie.Name = "Cental"; // cookie adý
    //cfg.ExpireTimeSpan = TimeSpan.FromDays(60); // cookie süresi 60 gün // TimeSpan.FromMinutes(30) 30 dakika & TimeSpan.FromHours(1) 1 saat & TimeSpan.FromDays(1) 1 gün & TimeSpan.FromDays(60) 60 gün 
    //cfg.SlidingExpiration = true; // kullanýcý iþlem yaptýkça cookie süresi uzatýlýr & false yaparsanýz belirtilen süre kadar geçerli olur
    //cfg.Cookie.HttpOnly = true; // cookieye javascript üzerinden eriþilemez & true yaparsanýz eriþilemez
    //cfg.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always; // https üzerinden çalýþýr & Always yaparsanýz sadece https üzerinden çalýþýr
    //cfg.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict; // cookieyi sadece kendi domaininde çalýþtýrýr // SameSiteMode.None; // cookieyi her yere gönderir
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  // https yönlendirme
app.UseStaticFiles(); // statik dosyalar

app.UseRouting(); // yönlendirme

app.UseAuthentication(); // kimlik doðrulama
app.UseAuthorization(); // yetkilendirme

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
