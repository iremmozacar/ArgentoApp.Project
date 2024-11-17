using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ArgentoApp.Frontend.Mvc.Data;
using ArgentoApp.Frontend.Mvc.Data.Entities;
using AspNetCoreHero.ToastNotification;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddNotyf(config =>
{
    config.Position = NotyfPosition.TopRight;
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
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

// Admin Area Route
app.MapAreaControllerRoute(
    name: "admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
    areaName: "Admin"
);

// Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Uygulama başlatıldığında veritabanını seed et
SeedDatabase(app);

app.Run();

// SeedDatabase metodu
static void SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    context.Database.Migrate();

    // Seed Roles
    if (!roleManager.Roles.Any())
    {
        roleManager.CreateAsync(new AppRole { Name = "Super Admin", Description = "Sistemdeki her türlü işi yapmaya yetkili rol" }).Wait();
        roleManager.CreateAsync(new AppRole { Name = "Admin", Description = "Sistemdeki yönetimsel işleri yapmaya yetkili rol" }).Wait();
        roleManager.CreateAsync(new AppRole { Name = "Customer", Description = "Müşterilerin rolü" }).Wait();
    }

    // Seed Users
    if (!userManager.Users.Any())
    {
        var user = new AppUser
        {
            UserName = "denizcoban",
            Email = "denizcoban@example.com",
            FirstName = "Deniz",
            LastName = "Çoban",
            EmailConfirmed = true
        };
        userManager.CreateAsync(user, "YourPassword123!").Wait();
        userManager.AddToRoleAsync(user, "Super Admin").Wait();
    }
}