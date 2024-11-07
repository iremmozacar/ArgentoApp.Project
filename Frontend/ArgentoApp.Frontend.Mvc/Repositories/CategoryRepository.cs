using System;
using ArgentoApp.Frontend.Mvc.Models;
using Newtonsoft.Json;

namespace ArgentoApp.Frontend.Mvc.Repositories;

public static class  CategoryRepository
{
    /// <summary>
    /// Bu metot API'dan aktif/pasif kategori bilgilerini çekip bir liste halinde döndürür. 
    /// </summary>
    /// <returns></returns>
public static async Task<List<CategoryModel>> GetActives (bool isActive= true)
{
        ResponseModel<List<CategoryModel>> responseCategoryModel = new();
        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Categories/GetActives/{isActives}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            responseCategoryModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryModel>>>(contentResponse);

        }
        List<CategoryModel> responseCategoryList = responseCategoryModel.IsSucceeded ? responseCategoryModel.Data : [];



        ProductsCategories model = new()
        {
            CategoryList = responseCategoryList,
            ProductList = null
        };

        return responseCategoryList;
    }

    public static async Task<List<CategoryModel>> GetAllAsync()
    {
        ResponseModel<List<CategoryModel>> responseCategoryModel = new();
        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Categories/GetAll");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            responseCategoryModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryModel>>>(contentResponse);

        }
        List<CategoryModel> responseCategoryList = responseCategoryModel.IsSucceeded ? responseCategoryModel.Data : [];



        ProductsCategories model = new()
        {
            CategoryList = responseCategoryList,
            ProductList = null
        };

        return responseCategoryList;
    }
}
