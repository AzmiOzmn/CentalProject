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


// about service g�rd���n zaman aboutmanager s�n�f�ndan bir nesne �rne�i al ve i�lemi onunla yap .
builder.Services.AddDbContext<CentalContext>();
builder.Services.AddIdentity<AppUser, AppRole>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<CentalContext>().AddErrorDescriber<CustomErrorDescriber>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());




builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddValidatorsFromAssemblyContaining<BrandValidater>();
builder.Services.AddServiceRegistrations();





builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(new AuthorizeFilter());
});

builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Login/Index"; // giri� yolu
    cfg.LogoutPath = "/Login/Logout"; // ��k�� yolu
    cfg.AccessDeniedPath = "/ErrorPage/AccessDenied"; // yetki yoksa y�nlendirilecek sayfa

});

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
app.UseStatusCodePagesWithReExecute("/ErrorPage/NotFound404", "?code={0}");
app.UseRouting(); // y�nlendirme

app.UseAuthentication(); // kimlik do�rulama
app.UseAuthorization(); // yetkilendirme


app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");







app.Run();