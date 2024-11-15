using System;
using System.Text.Json.Serialization;

namespace ArgentoApp.Frontend.Mvc.Models.Response;

public class ResponseModel<T>
{
    [JsonPropertyName("data")]
    public T Data { get; set; }

    [JsonPropertyName("error")]
    public object Error { get; set; }

    [JsonPropertyName("isSucceeded")]
    public bool IsSucceeded { get; set; }
}
