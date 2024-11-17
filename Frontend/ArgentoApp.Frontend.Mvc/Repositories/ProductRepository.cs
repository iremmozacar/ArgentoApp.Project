using System.Net.Http.Headers;
using System.Text;
using ArgentoApp.Frontend.Mvc.Extentions;
using ArgentoApp.Frontend.Mvc.Models;
using ArgentoApp.Frontend.Mvc.Models.Other;
using ArgentoApp.Frontend.Mvc.Models.Product;
using ArgentoApp.Frontend.Mvc.Models.Response;
using Newtonsoft.Json;

namespace ArgentoApp.Frontend.Mvc.Repositories
{
    public static class ProductRepository
    {
        private const string BaseUrl = "http://localhost:5000/api/Products";

        // Tüm ürünleri getirir
        public static async Task<List<ProductViewModel>> GetAllAsync()
        {
            using (HttpClient httpClient = new())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{BaseUrl}/GetAll");
                    response.EnsureSuccessStatusCode();

                    string content = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductViewModel>>>(content);
                    return responseModel?.Data ?? new List<ProductViewModel>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching products: {ex.Message}");
                    return new List<ProductViewModel>();
                }
            }
        }

        // Ana sayfa ürünlerini getirir
        public static async Task<List<ProductViewModel>> GetHomesAsync(bool isHome = true)
        {
            using (HttpClient httpClient = new())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{BaseUrl}/GetHomes/{isHome}");
                    response.EnsureSuccessStatusCode();

                    string content = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductViewModel>>>(content);
                    return responseModel?.Data ?? new List<ProductViewModel>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching home products: {ex.Message}");
                    return new List<ProductViewModel>();
                }
            }
        }

        // ID'ye göre ürün getirir
        public static async Task<ProductViewModel> GetByIdAsync(int id)
        {
            using (HttpClient httpClient = new())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{BaseUrl}/GetById/{id}");
                    response.EnsureSuccessStatusCode();

                    string content = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(content);
                    return responseModel?.Data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching product by ID: {ex.Message}");
                    return null;
                }
            }
        }

        // Yeni ürün oluşturur
        public static async Task<bool> CreateAsync(ProductCreateViewModel model)
        {
            using (HttpClient httpClient = new())
            {
                try
                {
                    if (model.Image != null)
                    {
                        using (Stream stream = model.Image.OpenReadStream())
                        {
                            var content = new MultipartFormDataContent();
                            var byteContent = new ByteArrayContent(stream.ToByteArray());
                            byteContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);
                            content.Add(byteContent, "Image", model.Image.FileName);
                            content.Add(new StringContent("products"), "FolderName");

                            HttpResponseMessage imageResponse = await httpClient.PostAsync("http://localhost:5000/api/Images/UploadImage", content);
                            var imageResponseString = await imageResponse.Content.ReadAsStringAsync();
                            var imageUploadResponse = JsonConvert.DeserializeObject<ResponseModel<ImageUploadModel>>(imageResponseString);

                            if (imageUploadResponse?.IsSucceeded == true)
                            {
                                model.ImageUrl = imageUploadResponse.Data.Url;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                    var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync($"{BaseUrl}/Create", stringContent);
                    var responseString = await response.Content.ReadAsStringAsync();
                    var createResponse = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(responseString);

                    return createResponse?.IsSucceeded ?? false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating product: {ex.Message}");
                    return false;
                }
            }
        }

        // Ürün günceller
        public static async Task<bool> UpdateAsync(ProductEditViewModel model)
        {
            using (HttpClient httpClient = new())
            {
                try
                {
                    if (model.Image != null)
                    {
                        using (Stream stream = model.Image.OpenReadStream())
                        {
                            var content = new MultipartFormDataContent();
                            var byteContent = new ByteArrayContent(stream.ToByteArray());
                            byteContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);
                            content.Add(byteContent, "Image", model.Image.FileName);
                            content.Add(new StringContent("products"), "FolderName");

                            HttpResponseMessage imageResponse = await httpClient.PostAsync("http://localhost:5000/api/Images/UploadImage", content);
                            var imageResponseString = await imageResponse.Content.ReadAsStringAsync();
                            var imageUploadResponse = JsonConvert.DeserializeObject<ResponseModel<ImageUploadModel>>(imageResponseString);

                            if (imageUploadResponse?.IsSucceeded == true)
                            {
                                model.ImageUrl = imageUploadResponse.Data.Url;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                    var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PutAsync($"{BaseUrl}/Update", stringContent);
                    var responseString = await response.Content.ReadAsStringAsync();
                    var updateResponse = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(responseString);

                    return updateResponse?.IsSucceeded ?? false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating product: {ex.Message}");
                    return false;
                }
            }
        }

        // Ürün siler
        public static async Task<bool> DeleteAsync(int id)
        {
            using (HttpClient httpClient = new())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{BaseUrl}/Delete/{id}");
                    response.EnsureSuccessStatusCode();

                    string content = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(content);

                    return responseModel?.IsSucceeded ?? false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting product: {ex.Message}");
                    return false;
                }
            }
        }

        // Ürünün aktif durumunu günceller
        public static async Task<ProductViewModel> UpdateIsActiveAsync(int id)
        {
            using (HttpClient httpClient = new())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{BaseUrl}/UpdateIsActive/{id}");
                    response.EnsureSuccessStatusCode();

                    var product = await GetByIdAsync(id);
                    return product;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating product active state: {ex.Message}");
                    return null;
                }
            }
        }

        // Ürünün ana sayfa durumunu günceller
        public static async Task<bool> UpdateIsHomeAsync(int id)
        {
            using (HttpClient httpClient = new())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{BaseUrl}/UpdateIsHome/{id}");
                    response.EnsureSuccessStatusCode();

                    string content = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel<bool?>>(content);

                    return responseModel?.IsSucceeded ?? false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating product home state: {ex.Message}");
                    return false;
                }
            }
        }
    }
}