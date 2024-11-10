using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArgentoApp.Frontend.Mvc.Models.Product;

public class ProductCreateViewModel
{
    [JsonPropertyName("name")]
    [Display(Name = "Ürün Adı")]
    public string Name { get; set; }

    [JsonPropertyName("isActive")]
    [Display(Name = "Aktif mi?")]
    public bool IsActive { get; set; }

    [JsonPropertyName("properties")]
    [Display(Name = "Özellikler")]
    public string Properties { get; set; }

    [JsonPropertyName("price")]
    [Display(Name = "Fiyat")]
    public decimal Price { get; set; }

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("isHome")]
    [Display(Name = "Anasayfa Ürünü mü?")]
    public bool IsHome { get; set; }

    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }

    [Display(Name = "Kategori seç")]
    public List<SelectListItem> Categories { get; set; }
    public IFormFile Image { get; set; }

}
