using System;
using System.Text.Json.Serialization;

namespace ArgentoApp.Frontend.Mvc.Models.Category;
public class CategoryViewModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}
