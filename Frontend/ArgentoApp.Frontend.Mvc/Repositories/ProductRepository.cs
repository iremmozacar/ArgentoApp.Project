using System;
using System.ComponentModel;
using ArgentoApp.Frontend.Mvc.Models;
using Newtonsoft.Json;

namespace ArgentoApp.Frontend.Mvc.Repositories;

public static class ProductRepository
{
public static async Task<List<ProductModel>> GetHomesAsync (bool isHome=true){

        ResponseModel<List<ProductModel>> responseProductModel = new();
        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5000/api/Categories/GetHomes/{isHome}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            responseProductModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductModel>>>(contentResponse);

        }
        List<ProductModel> responseProductList = responseProductModel.IsSucceeded ? responseProductModel.Data : [];


        return responseProductList;
    }

}
