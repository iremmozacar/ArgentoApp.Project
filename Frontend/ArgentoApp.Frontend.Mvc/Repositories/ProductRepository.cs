using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ArgentoApp.Frontend.Mvc.Models;
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
        public static async Task<List<ProductModel>> GetHomesAsync(bool isHome = true)
        {
            ResponseModel<List<ProductModel>> responseProductModel = null;

            using (HttpClient httpClient = new HttpClient())
            {
                // API çağrısında isHome parametresini doğru şekilde ekliyoruz
                string url = $"http://localhost:5259/api/Categories/GetHomes/{isHome}";
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    responseProductModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductModel>>>(contentResponse);
                }
            }

            // Null kontrolü ekleyerek listeyi oluşturuyoruz
            List<ProductModel> responseProductList = (responseProductModel != null && responseProductModel.IsSucceeded)
                ? responseProductModel.Data
                : new List<ProductModel>();

            return responseProductList;
        }
    }
}