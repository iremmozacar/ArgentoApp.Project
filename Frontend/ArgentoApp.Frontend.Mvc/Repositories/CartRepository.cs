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
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:5000/api/carts/addtocart", stringContent);
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
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5000/api/Carts/GetCart/{userId}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            responseViewModel = JsonConvert.DeserializeObject<ResponseModel<CartViewModel>>(contentResponse);
        }
        CartViewModel response = responseViewModel.IsSucceeded ?
                    responseViewModel.Data : null;
        return response;
    }

    public static async Task<CartItemViewModel> GetCartItemAsync(int cartItemId)
    {
        ResponseModel<CartItemViewModel> responseViewModel = new();
        using (HttpClient httpClient = new())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5000/api/Carts/GetCartItem/{cartItemId}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            responseViewModel = JsonConvert.DeserializeObject<ResponseModel<CartItemViewModel>>(contentResponse);
        }
        return responseViewModel.IsSucceeded ? responseViewModel.Data : null;
    }

    public static async Task<ReturnChangeQuantityModel> ChangeQuantityAsync(int cartItemId, int quantity, string userId)
    {
        using (HttpClient httpClient = new())
        {
            var serializeModel = JsonConvert.SerializeObject(new { cartItemId, quantity });
            var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:5000/api/carts/changequantity", stringContent);
            var httpResponseMessageString = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel<ReturnChangeQuantityModel>>(httpResponseMessageString);


            ReturnChangeQuantityModel result = new();
            var cartItem = await GetCartItemAsync(cartItemId);
            if (cartItem != null)
            {
                result.CartItemTotal = cartItem.Quantity * cartItem.Product.Price;
            }
            var cart = await GetCartAsync(userId);
            if (cart != null)
            {
                result.SubTotal = cart.GetTotalPrice();
                result.CartTotal = result.SubTotal > 20000 ? result.SubTotal : result.SubTotal + 1000;
            }
            return result;
        }
    }
    public static async Task<bool> DeleteCartItemAsync(int cartItemId)
    {
        ResponseModel<CartViewModel> response = new();
        using (HttpClient httpClient = new())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync($"http://localhost:5000/api/Carts/DeleteItem/{cartItemId}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            response = JsonConvert.DeserializeObject<ResponseModel<CartViewModel>>(contentResponse);

            return response.IsSucceeded;
        }
    }
    public static async Task<bool> ClearCartAsync(int cartId)
    {
        ResponseModel<CartViewModel> response = new();
        using (HttpClient httpClient = new())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync($"http://localhost:5200/api/Carts/ClearCart/{cartId}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            response = JsonConvert.DeserializeObject<ResponseModel<CartViewModel>>(contentResponse);

            return response.IsSucceeded;
        }
    }
}
