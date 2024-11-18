using System;
using System.Text;
using ArgentoApp.Frontend.Mvc.Models.Cart;
using ArgentoApp.Frontend.Mvc.Models.Product;
using ArgentoApp.Frontend.Mvc.Models.Response;
using Newtonsoft.Json;

namespace ArgentoApp.Frontend.Mvc.Repositories;

public class CartRepository
{
    public static async Task<bool> AddToCartAsync(AddToCartViewModel model)
    {
        using (HttpClient httpClient = new())
        {
            var serializeModel = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:5200/api/carts/addtocart", stringContent);
            var httpResponseMessageString = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseProduct = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(httpResponseMessageString);
            return responseProduct.IsSucceeded;
        }
    }
    public static async Task<CartViewModel> GetCartAsync(string userId)
    {
        ResponseModel<CartViewModel> responseViewModel = new();
        using (HttpClient httpClient = new())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5200/api/Carts/GetCart/{userId}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            responseViewModel = JsonConvert.DeserializeObject<ResponseModel<CartViewModel>>(contentResponse);
        }
        CartViewModel response = responseViewModel.IsSucceeded ?
                    responseViewModel.Data : null;
        return response;
    }
}
