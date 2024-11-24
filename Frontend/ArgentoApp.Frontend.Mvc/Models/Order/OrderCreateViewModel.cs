using System;
using System.Text.Json.Serialization;
using ArgentoApp.Frontend.Mvc.Models.Cart;
using ArgentoApp.Frontend.Mvc.Models.Order;

namespace ArgentoApp.Frontend.Mvc.Models.Other;

public class OrderCreateViewModel
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("paymentType")]
    public int PaymentType { get; set; }

    [JsonPropertyName("orderItems")]
    public List<OrderItemViewModel> OrderItems { get; set; }

    public CartViewModel Cart { get; set; }
}
