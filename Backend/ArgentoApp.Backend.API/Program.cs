using ArgentoApp.Backend.Business.Abstract;
using ArgentoApp.Backend.Business.Concrete;
using ArgentoApp.Backend.Data;
using ArgentoApp.Backend.Data.Abstact;
using ArgentoApp.Backend.Data.Abstract;
using ArgentoApp.Backend.Data.Concrete.Repositories;
using ArgentoApp.Backend.Shared.Helpers;
using ArgentoApp.Backend.Shared.Helpers.Abstract;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
#region Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
#endregion
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

#region Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();
#endregion

builder.Services.AddScoped<IImageHelper, ImageHelper>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();//wwwroot klasörünü kullanıma açar

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
