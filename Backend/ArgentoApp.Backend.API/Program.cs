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

// CORS ayarları
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
        builder.AllowAnyOrigin()   // Tüm origin'lere izin verir
               .AllowAnyMethod()   // Tüm HTTP metodlarına izin verir
               .AllowAnyHeader()); // Tüm başlıklara izin verir
});

// Diğer servisler
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

//<<<Repositories>>>
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

//<<<Services>>>>
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

//<<<ImageHelper>>>>
builder.Services.AddScoped<IImageHelper, ImageHelper>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// API Program.cs'de CORS ayarları
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Middleware'de CORS'u etkinleştirin
app.UseCors("AllowAll");
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();