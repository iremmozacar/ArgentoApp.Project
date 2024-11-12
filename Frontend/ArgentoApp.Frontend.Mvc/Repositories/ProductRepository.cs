using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ArgentoApp.Frontend.Mvc.Models;
using ArgentoApp.Frontend.Mvc.Models.Other;
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
            ResponseModel<List<ProductViewModel>> responseProductViewModel = null;

            using (HttpClient httpClient = new HttpClient())
            {
                // API çağrısında isHome parametresini doğru şekilde ekliyoruz
                string url = $"http://localhost:5000/api/Categories/GetHomes/{isHome}";
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductViewModel>>>(contentResponse);
                }
            }

            List<ProductViewModel> responseProductList = (responseProductViewModel != null && responseProductViewModel.IsSucceeded)
                ? responseProductViewModel.Data
                : new List<ProductViewModel>();

            return responseProductList;
        }
        public static async Task<List<ProductViewModel>> GetAllAsync()
        {
            ResponseModel<List<ProductViewModel>> responseProductViewModel = null;

            using (HttpClient httpClient = new HttpClient())
            {
                // Make the GET request to fetch all products
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/products/getall");

                // Check if the response status is OK
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into the ResponseModel
                    responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductViewModel>>>(contentResponse);

                    // Log the response to the console for debugging
                    Console.WriteLine($"API Response: {contentResponse}");
                }
                else
                {
                    // Optionally handle unsuccessful status codes
                    Console.WriteLine("API request failed with status code: " + httpResponseMessage.StatusCode);
                    return new List<ProductViewModel>();
                }
            }

            // Ensure that the response is valid, and return the product list, or return an empty list if no data
            List<ProductViewModel> responseProductList = (responseProductViewModel != null && responseProductViewModel.IsSucceeded)
                ? responseProductViewModel.Data
                : new List<ProductViewModel>();

            // Log the final result to help track the list of products
            Console.WriteLine($"Number of products fetched: {responseProductList.Count}");

            return responseProductList;
        }
        public static async Task<ProductViewModel> GetByIdAsync(int id)
        {
            ResponseModel<ProductViewModel> responseProductViewModel = new();
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5200/api/Products/GetById/{id}");
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(contentResponse);
            }
            ProductViewModel responseProduct = responseProductViewModel.IsSucceeded ?
                        responseProductViewModel.Data : null;
            return responseProduct;
        }
        public static async Task<bool> CreateAsync(ProductCreateViewModel model)
        {
            using (HttpClient httpClient = new())
            {
                // Prepare image upload
                using (Stream stream = model.Image.OpenReadStream())
                using (MemoryStream memoryStream = new())
                {
                    await stream.CopyToAsync(memoryStream);  // Copy the stream to a MemoryStream
                    byte[] bytes = memoryStream.ToArray();   // Convert MemoryStream to byte array

                    var content = new MultipartFormDataContent();
                    var byteContent = new ByteArrayContent(bytes);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);
                    content.Add(byteContent, "Image", model.Image.FileName);
                    content.Add(new StringContent("products"), "FolderName");

                    // Send the HTTP request
                    HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:5200/api/Images/UploadImage", content);
                    var httpResponseMessageString = await httpResponseMessage.Content.ReadAsStringAsync();

                    // Deserialize the response
                    var response = JsonConvert.DeserializeObject<ResponseModel<ImageUploadModel>>(httpResponseMessageString);

                    // Check response and assign URL if succeeded
                    if (response != null && response.IsSucceeded)
                    {
                        model.ImageUrl = response.Data.Url;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
}
}
