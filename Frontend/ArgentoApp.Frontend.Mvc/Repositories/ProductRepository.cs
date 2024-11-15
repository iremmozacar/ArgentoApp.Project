using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ArgentoApp.Frontend.Mvc.Extentions;
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
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5000/api/Products/GetById/{id}");
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
                //Resim Yükleme işlemini yapıyoruz
                using (Stream stream = model.Image.OpenReadStream())
                {
                    var content = new MultipartFormDataContent();
                    byte[] bytes = stream.ToByteArray();
                    var byteContent = new ByteArrayContent(bytes);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);
                    content.Add(byteContent, "Image", model.Image.FileName);
                    content.Add(new StringContent("products"), "FolderName");
                    HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:5000/api/Images/UploadImage", content);
                    var httpResponseMessageString = await httpResponseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<ResponseModel<ImageUploadModel>>(httpResponseMessageString);
                    if (response.IsSucceeded)
                    {
                        model.ImageUrl = response.Data.Url;
                    }
                    else
                    {
                        return response.IsSucceeded;
                    }
                }

                //Ürün Ekleme işlemini yapıyoruz
                var serializeModel = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessageProduct = await httpClient.PostAsync("http://localhost:5200/api/Products/Create", stringContent);
                var httpResponseMessageProductString = await httpResponseMessageProduct.Content.ReadAsStringAsync();
                var responseProduct = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(httpResponseMessageProductString);
                return responseProduct.IsSucceeded;
            }

        }
    


        public static async Task<bool> UpdateAsync(ProductEditViewModel model)
        {
            using (HttpClient httpClient = new())
            {
                if (model.Image != null)
                {
                    //Resim Yükleme işlemini yapıyoruz
                    using (Stream stream = model.Image.OpenReadStream())
                    {
                        var content = new MultipartFormDataContent();
                        byte[] bytes = stream.ToByteArray();
                        var byteContent = new ByteArrayContent(bytes);
                        byteContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);
                        content.Add(byteContent, "Image", model.Image.FileName);
                        content.Add(new StringContent("products"), "FolderName");
                        HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:5200/api/Images/UploadImage", content);
                        var httpResponseMessageString = await httpResponseMessage.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject<ResponseModel<ImageUploadModel>>(httpResponseMessageString);
                        if (response.IsSucceeded)
                        {
                            model.ImageUrl = response.Data.Url;
                        }
                        else
                        {
                            return response.IsSucceeded;
                        }
                    }
                }

                //Ürün Güncelleme işlemini yapıyoruz
                var serializeModel = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessageProduct = await httpClient.PutAsync("http://localhost:5000/api/Products/Update", stringContent);
                var httpResponseMessageProductString = await httpResponseMessageProduct.Content.ReadAsStringAsync();
                var responseProduct = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(httpResponseMessageProductString);
                return responseProduct.IsSucceeded;
            }

        }
        public static async Task<bool> DeleteAsync(int id)
        {
            ResponseModel<ProductViewModel> responseProductViewModel = new();
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync($"http://localhost:5000/api/Products/Delete/{id}");
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(contentResponse);

                return responseProductViewModel.IsSucceeded;
            }
        }
    }
    
}