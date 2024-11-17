using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ArgentoApp.Frontend.Mvc.Models;
using Newtonsoft.Json;
using ArgentoApp.Frontend.Mvc.Repositories;
using ArgentoApp.Frontend.Mvc.Models.Category;
using ArgentoApp.Frontend.Mvc.Models.Product;
using ArgentoApp.Frontend.Mvc.Models.Response;

namespace ArgentoApp.Frontend.Mvc.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        #region Kategorileri API'dan çekiyoruz
        ResponseModel<List<CategoryViewModel>> responseCategoryViewModel = new();
        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Categories/GetActives/true");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            responseCategoryViewModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryViewModel>>>(contentResponse);
        }
        List<CategoryViewModel> responseCategoryList = (responseCategoryViewModel != null && responseCategoryViewModel.IsSucceeded)
            ? responseCategoryViewModel.Data
            : new List<CategoryViewModel>();
        #endregion

        #region Ürünleri API'dan çekiyoruz
        ResponseModel<List<ProductViewModel>> responseProductViewModel = new();
        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Products/GetHomes/true");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductViewModel>>>(contentResponse);
        }
        List<ProductViewModel> responseProductList = (responseProductViewModel != null && responseProductViewModel.IsSucceeded)
            ? responseProductViewModel.Data
            : new List<ProductViewModel>();
        #endregion

        // Debug: Ürünlerin doğru şekilde çekilip çekilmediğini görmek için
        if (responseProductList.Count == 0)
        {
            Debug.WriteLine("Ürün listesi boş.");
        }

        // Model oluşturma
        ProductsCategoriesViewModel model = new()
        {
            CategoryList = responseCategoryList,
            ProductList = responseProductList
        };

        return View(model);
    }
}