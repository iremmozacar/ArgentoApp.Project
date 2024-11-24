using System;
using System.Text;
using ArgentoApp.Frontend.Mvc.Models.Other;
using ArgentoApp.Frontend.Mvc.Models.Product;
using ArgentoApp.Frontend.Mvc.Models.Response;
using Newtonsoft.Json;

namespace ArgentoApp.Frontend.Mvc.Repositories;

public class OrderRepository
{
    public static async Task<ResponseModel<ProductViewModel>> AddOrderAsync(OrderCreateViewModel model)
    {
        using (HttpClient httpClient = new())
        {
            var serializeModel = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:5000/api/orders/addorder", stringContent);
            var httpResponseMessageString = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(httpResponseMessageString);
            return response;
        }
    }

}
