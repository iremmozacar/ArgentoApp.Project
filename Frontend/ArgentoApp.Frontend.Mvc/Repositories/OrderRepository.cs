using System;
using System.Text;
using ArgentoApp.Frontend.Mvc.Models.Order;
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
    public static async Task<List<OrderViewModel>> GetOrdersByUserIdAsync(string userId)
    {
        ResponseModel<List<OrderViewModel>> responseModel = new();
        using (HttpClient httpClient = new())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5000/api/Orders/GetOrdersByUserId/{userId}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            responseModel = JsonConvert.DeserializeObject<ResponseModel<List<OrderViewModel>>>(contentResponse);
        }
        List<OrderViewModel> responseList = responseModel.IsSucceeded ?
                    responseModel.Data : [];
        return responseList;
    }
}
