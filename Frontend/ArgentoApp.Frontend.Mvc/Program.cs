var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
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
