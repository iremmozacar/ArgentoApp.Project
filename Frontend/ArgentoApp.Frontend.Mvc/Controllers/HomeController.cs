using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ArgentoApp.Frontend.Mvc.Models;
using Newtonsoft.Json;
using ArgentoApp.Frontend.Mvc.Repositories;

namespace ArgentoApp.Frontend.Mvc.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        #region Kategorileri API'dan çekiyoruz
        ResponseModel<List<CategoryModel>> responseCategoryModel = new();
        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5200/api/Categories/GetActives/true");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            responseCategoryModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryModel>>>(contentResponse);
        }
        List<CategoryModel> responseCategoryList = (responseCategoryModel != null && responseCategoryModel.IsSucceeded)
            ? responseCategoryModel.Data
            : new List<CategoryModel>();
        #endregion

        #region Ürünleri API'dan çekiyoruz
        ResponseModel<List<ProductModel>> responseProductModel = new();
        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5200/api/Products/GetHomes/true");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            responseProductModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductModel>>>(contentResponse);
        }
        List<ProductModel> responseProductList = (responseProductModel != null && responseProductModel.IsSucceeded)
            ? responseProductModel.Data
            : new List<ProductModel>();
        #endregion

        // Debug: Ürünlerin doğru şekilde çekilip çekilmediğini görmek için
        if (responseProductList.Count == 0)
        {
            Debug.WriteLine("Ürün listesi boş.");
        }

        // Model oluşturma
        ProductsCategories model = new()
        {
            CategoryList = responseCategoryList,
            ProductList = responseProductList
        };

        return View(model);
    }
}