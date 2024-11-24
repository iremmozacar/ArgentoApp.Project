using System;
using System.Text.Json.Serialization;

namespace ArgentoApp.Frontend.Mvc.Models.Order;

public class OrderItemViewModel
{
    [JsonPropertyName("productId")]
    public int ProductId { get; set; }

    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}
