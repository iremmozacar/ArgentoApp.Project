using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using ArgentoApp.Frontend.Mvc.Models;
using Newtonsoft.Json;

namespace ArgentoApp.Frontend.Mvc.Repositories
{
    public static class CategoryRepository
    {
        /// <summary>
        /// Bu metot API'den aktif/pasif kategori bilgilerini çekip bir liste halinde döndürür. 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CategoryModel>> GetActives(bool isActive = true)
        {
            ResponseModel<List<CategoryModel>> responseCategoryModel = new();

            using (HttpClient httpClient = new HttpClient())
            {
                // API çağrısında isActive parametresini doğru şekilde ekliyoruz
                string url = $"http://localhost:5000/api/Categories/GetActives/{isActive}";
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    responseCategoryModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryModel>>>(contentResponse);
                }
            }

            // Null kontrolü ekleyerek listeyi oluşturuyoruz
            List<CategoryModel> responseCategoryList = (responseCategoryModel != null && responseCategoryModel.IsSucceeded)
                ? responseCategoryModel.Data
                : new List<CategoryModel>();

            return responseCategoryList;
        }

        public static async Task<List<CategoryModel>> GetAllAsync()
        {
            ResponseModel<List<CategoryModel>> responseCategoryModel = new();

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Categories/GetAll");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    responseCategoryModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryModel>>>(contentResponse);
                }
            }

            // Null kontrolü ekleyerek listeyi oluşturuyoruz
            List<CategoryModel> responseCategoryList = (responseCategoryModel != null && responseCategoryModel.IsSucceeded)
                ? responseCategoryModel.Data
                : new List<CategoryModel>();

            return responseCategoryList;
        }
    }
}