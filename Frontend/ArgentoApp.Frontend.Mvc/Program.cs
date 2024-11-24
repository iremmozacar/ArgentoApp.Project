using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ArgentoApp.Frontend.Mvc.Data;
using ArgentoApp.Frontend.Mvc.Data.Entities;
using AspNetCoreHero.ToastNotification;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddNotyf(config =>
{
    config.Position = NotyfPosition.TopRight;
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;

});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

//localhost:5000/admin/home/index
app.MapAreaControllerRoute(
    name: "admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
    areaName: "Admin"
);


//localhost:5000/Product/Create
//localhost:5000/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
