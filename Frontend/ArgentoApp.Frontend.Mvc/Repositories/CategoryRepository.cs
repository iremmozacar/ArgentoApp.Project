using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using ArgentoApp.Frontend.Mvc.Models;
using Newtonsoft.Json;
using ArgentoApp.Frontend.Mvc.Models.Category;

namespace ArgentoApp.Frontend.Mvc.Repositories
{
    public static class CategoryRepository
    {
        /// <summary>
        /// Bu metot API'den aktif/pasif kategori bilgilerini çekip bir liste halinde döndürür. 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CategoryViewModel>> GetActives(bool isActive = true)
        {
            ResponseModel<List<CategoryViewModel>> responseCategoryViewModel = new();

            using (HttpClient httpClient = new HttpClient())
            {
                // API çağrısında isActive parametresini doğru şekilde ekliyoruz
                string url = $"http://localhost:5000/api/Categories/GetActives/{isActive}";
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    responseCategoryViewModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryViewModel>>>(contentResponse);
                }
            }

            // Null kontrolü ekleyerek listeyi oluşturuyoruz
            List<CategoryViewModel> responseCategoryList = (responseCategoryViewModel != null && responseCategoryViewModel.IsSucceeded)
                ? responseCategoryViewModel.Data
                : new List<CategoryViewModel>();

            return responseCategoryList;
        }

        public static async Task<List<CategoryViewModel>> GetAllAsync()
        {
            ResponseModel<List<CategoryViewModel>> responseCategoryViewModel = new();

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Categories/GetAll");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    responseCategoryViewModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryViewModel>>>(contentResponse);
                }
            }

            // Null kontrolü ekleyerek listeyi oluşturuyoruz
            List<CategoryViewModel> responseCategoryList = (responseCategoryViewModel != null && responseCategoryViewModel.IsSucceeded)
                ? responseCategoryViewModel.Data
                : new List<CategoryViewModel>();

            return responseCategoryList;
        }
    }
}