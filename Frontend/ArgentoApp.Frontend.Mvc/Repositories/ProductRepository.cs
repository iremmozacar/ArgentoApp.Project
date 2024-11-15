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
        public static async Task<List<ProductViewModel>> GetHomesAsync(bool isHome = true)
        {
            ResponseModel<List<ProductViewModel>> responseProductViewModel = new();
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5000/api/Products/GetHomes/{isHome}");
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductViewModel>>>(contentResponse);
            }
            List<ProductViewModel> responseProductList = responseProductViewModel.IsSucceeded ?
                        responseProductViewModel.Data : [];
            return responseProductList;
        }
        public static async Task<List<ProductViewModel>> GetAllAsync()
        {
            ResponseModel<List<ProductViewModel>> responseProductViewModel = new();
            using (HttpClient httpClient = new())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Products/GetAll");

                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        throw new Exception($"API call failed with status code: {httpResponseMessage.StatusCode}");
                    }

                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                    responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductViewModel>>>(contentResponse);

                    if (responseProductViewModel == null || !responseProductViewModel.IsSucceeded)
                    {
                        throw new Exception("API response is null or unsuccessful.");
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.WriteLine($"Error fetching products: {ex.Message}");
                    // Return an empty list to avoid null reference issues
                    return new List<ProductViewModel>();
                }
            }
            return responseProductViewModel.Data ?? new List<ProductViewModel>();
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
                HttpResponseMessage httpResponseMessageProduct = await httpClient.PostAsync("http://localhost:5000/api/Products/Create", stringContent);
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
        public static async Task<ProductViewModel> UpdateIsActiveAsync(int id)
        {
            ResponseModel<bool?> responseModel = new();
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5000/api/Products/UpdateIsActive/{id}");
                string contentResponse = await httpResponseMessage.Content?.ReadAsStringAsync();
                responseModel = JsonConvert.DeserializeObject<ResponseModel<bool?>>(contentResponse);
                var product = await GetByIdAsync(id);
                return product;
            }
        }
        public static async Task<bool> UpdateIsHomeAsync(int id)
        {
            ResponseModel<bool?> responseModel = new();
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5000/api/Products/UpdateIsHome/{id}");
                string contentResponse = await httpResponseMessage.Content?.ReadAsStringAsync();
                responseModel = JsonConvert.DeserializeObject<ResponseModel<bool?>>(contentResponse);
                return responseModel.IsSucceeded;
            }
        }
    }
}