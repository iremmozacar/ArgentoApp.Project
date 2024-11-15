using System.Net.Http.Headers;
using System.Text;
using ArgentoApp.Frontend.Mvc.Extentions;
using ArgentoApp.Frontend.Mvc.Models;
using ArgentoApp.Frontend.Mvc.Models.Other;
using ArgentoApp.Frontend.Mvc.Models.Product;
using Newtonsoft.Json;

namespace ArgentoApp.Frontend.Mvc.Repositories
{
    public static class ProductRepository
    {
        private const string BaseApiUrl = "http://localhost:5000/api/";
        private static readonly ILogger _logger = LoggerFactory.Create(builder => builder.AddConsole())
                                                             .CreateLogger(typeof(ProductRepository).FullName);

        public class ApiResponse<T>
        {
            public T Data { get; set; }
            public string Error { get; set; }
        }

        public static async Task<List<ProductViewModel>> GetHomesAsync(bool isHome = true)
        {
            ResponseModel<List<ProductViewModel>> responseProductViewModel = new();
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5000/api/Products/GetHomes/{isHome}");
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductViewModel>>>(contentResponse);
            }
            return responseProductViewModel.IsSucceeded
                ? responseProductViewModel.Data
                : new List<ProductViewModel>();
        }

        public static async Task<ApiResponse<List<ProductViewModel>>> GetAllAsync()
        {
            try
            {
                using (HttpClient httpClient = new())
                {
                    httpClient.BaseAddress = new Uri(BaseApiUrl);
                    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("Products/GetAll");

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                        var responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<List<ProductViewModel>>>(contentResponse);

                        if (responseProductViewModel != null && responseProductViewModel.IsSucceeded)
                        {
                            return new ApiResponse<List<ProductViewModel>>
                            {
                                Data = responseProductViewModel.Data ?? new List<ProductViewModel>(),
                                Error = null
                            };
                        }
                    }

                    return new ApiResponse<List<ProductViewModel>>
                    {
                        Data = new List<ProductViewModel>(),
                        Error = "API yanıt vermedi veya başarısız yanıt döndü."
                    };
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "API bağlantısı sırasında hata oluştu: {Message}", ex.Message);
                return new ApiResponse<List<ProductViewModel>>
                {
                    Data = new List<ProductViewModel>(),
                    Error = "API'ye bağlanırken bir hata oluştu."
                };
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "API yanıtı deserialize edilirken hata oluştu: {Message}", ex.Message);
                return new ApiResponse<List<ProductViewModel>>
                {
                    Data = new List<ProductViewModel>(),
                    Error = "API yanıtı işlenirken bir hata oluştu."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Beklenmeyen bir hata oluştu: {Message}", ex.Message);
                return new ApiResponse<List<ProductViewModel>>
                {
                    Data = new List<ProductViewModel>(),
                    Error = "Beklenmeyen bir hata oluştu."
                };
            }
        }

        public static async Task<ProductViewModel> GetByIdAsync(int id)
        {
            try
            {
                using (HttpClient httpClient = new())
                {
                    httpClient.BaseAddress = new Uri(BaseApiUrl);
                    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"Products/GetById/{id}");

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                        var responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(contentResponse);

                        if (responseProductViewModel != null && responseProductViewModel.IsSucceeded)
                        {
                            return responseProductViewModel.Data;
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün getirilirken hata oluştu: {Message}", ex.Message);
                return null;
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
                HttpResponseMessage httpResponseMessageProduct = await httpClient.PutAsync("http://localhost:5200/api/Products/Update", stringContent);
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
                HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync($"http://localhost:5200/api/Products/Delete/{id}");
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                responseProductViewModel = JsonConvert.DeserializeObject<ResponseModel<ProductViewModel>>(contentResponse);

                return responseProductViewModel.IsSucceeded;
            }
        }

    }
}