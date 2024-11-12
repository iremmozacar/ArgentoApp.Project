using System;
using System.Text.Json.Serialization;

namespace ArgentoApp.Frontend.Mvc.Models.Other;

public class ImageUploadModel
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

