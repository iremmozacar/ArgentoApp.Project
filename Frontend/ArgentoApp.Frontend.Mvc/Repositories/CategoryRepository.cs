using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using ArgentoApp.Frontend.Mvc.Models;
using Newtonsoft.Json;
using ArgentoApp.Frontend.Mvc.Models.Category;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArgentoApp.Frontend.Mvc.Repositories
{
    public static class CategoryRepository
    {

        private const string BaseApiUrl = "http://localhost:5000/api/";
        private static readonly ILogger _logger = LoggerFactory.Create(builder => builder.AddConsole())
                                                             .CreateLogger(typeof(CategoryRepository).FullName);

        public static async Task<List<CategoryViewModel>> GetActives(bool isActive = true)
        {
            ResponseModel<List<CategoryViewModel>> responseCategoryViewModel = new();
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5000/api/Categories/GetActives/{isActive}");
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                responseCategoryViewModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryViewModel>>>(contentResponse);
            }
            List<CategoryViewModel> responseCategoryList = responseCategoryViewModel.IsSucceeded ?
                        responseCategoryViewModel.Data : [];
            return responseCategoryList;
        }

        public static async Task<ProductRepository.ApiResponse<List<CategoryViewModel>>> GetAllAsync()
        {
            try
            {
                using (HttpClient httpClient = new())
                {
                    httpClient.BaseAddress = new Uri(BaseApiUrl);
                    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("Categories/GetAll");

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                        var responseCategoryViewModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryViewModel>>>(contentResponse);

                        if (responseCategoryViewModel != null && responseCategoryViewModel.IsSucceeded)
                        {
                            return new ProductRepository.ApiResponse<List<CategoryViewModel>>
                            {
                                Data = responseCategoryViewModel.Data ?? new List<CategoryViewModel>(),
                                Error = null
                            };
                        }
                    }
                    return new ProductRepository.ApiResponse<List<CategoryViewModel>>
                    {
                        Data = new List<CategoryViewModel>(),
                        Error = "API yanıt vermedi veya başarısız yanıt döndü."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori listesi alınırken hata oluştu: {Message}", ex.Message);
                return new ProductRepository.ApiResponse<List<CategoryViewModel>>
                {
                    Data = new List<CategoryViewModel>(),
                    Error = "Kategoriler yüklenirken bir hata oluştu."
                };
            }
        }
      public static async Task<ProductRepository.ApiResponse<List<SelectListItem>>> GetSelectListItemsAsync()
        {
            try
            {
                var apiResponse = await GetAllAsync();

                if (!string.IsNullOrEmpty(apiResponse.Error))
                {
                    return new ProductRepository.ApiResponse<List<SelectListItem>>
                    {
                        Data = new List<SelectListItem>(),
                        Error = apiResponse.Error
                    };
                }

                var selectList = apiResponse.Data.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

                return new ProductRepository.ApiResponse<List<SelectListItem>>
                {
                    Data = selectList,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori select list oluşturulurken hata oluştu: {Message}", ex.Message);
                return new ProductRepository.ApiResponse<List<SelectListItem>>
                {
                    Data = new List<SelectListItem>(),
                    Error = "Kategoriler yüklenirken bir hata oluştu."
                };
            }
        }

    }
}