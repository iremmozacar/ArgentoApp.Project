using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArgentoApp.Frontend.Mvc.Models;
using ArgentoApp.Frontend.Mvc.Models.Product;
using Newtonsoft.Json;

namespace ArgentoApp.Frontend.Mvc.Repositories
{
    public static class ProductRepository
    {
        /// <summary>
        /// Bu metot API'den ürün bilgilerini çekip ana sayfada görüntülenecek ürün listesini döndürür.
        /// </summary>
        /// <param name="isHome">Ana sayfa için ürün listesi almak isteniyorsa true olarak ayarlanır.</param>
        /// <returns>Ürün model listesini döndürür.</returns>
        public static async Task<List<ProductViewModel>> GetHomesAsync(bool isHome = true)
        {
            ResponseModel<List<ProductViewModel>> responseProductModel = null;

            using (HttpClient httpClient = new HttpClient())
            {
                // API çağrısında isHome parametresini doğru şekilde ekliyoruz
                string url = $"http://localhost:5000/api/Categories/GetHomes/{isHome}";
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    responseProductModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductViewModel>>>(contentResponse);
                }
            }

            List<ProductViewModel> responseProductList = (responseProductModel != null && responseProductModel.IsSucceeded)
                ? responseProductModel.Data
                : new List<ProductViewModel>();

            return responseProductList;
        }
        public static async Task<List<ProductViewModel>> GetAllAsync()
        {
            ResponseModel<List<ProductViewModel>> responseProductViewModel = null;

            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/products/getall");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductViewModel>>>(contentResponse);
                }
            }

            // Null kontrolü ve IsSucceeded özelliği kontrolü
            List<ProductViewModel> responseProductList = (responseProductViewModel != null && responseProductViewModel.IsSucceeded)
                ? responseProductViewModel.Data
                : new List<ProductViewModel>(); // Boş liste döndür

            return responseProductList;
        }
    }
}
