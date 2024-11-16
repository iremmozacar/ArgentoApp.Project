using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using ArgentoApp.Frontend.Mvc.Models;
using Newtonsoft.Json;
using ArgentoApp.Frontend.Mvc.Models.Category;
using Microsoft.AspNetCore.Mvc.Rendering;
using ArgentoApp.Frontend.Mvc.Models.Response;

namespace ArgentoApp.Frontend.Mvc.Repositories
{
    public static class CategoryRepository
    {
        public static async Task<List<CategoryViewModel>> GetActives(bool isActive = true)
        {
            ResponseModel<List<CategoryViewModel>> responseCategoryViewModel = null;

            using (HttpClient httpClient = new())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5200/api/Categories/GetActives/{isActive}");

                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        throw new Exception($"API call failed with status code: {httpResponseMessage.StatusCode}");
                    }

                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    responseCategoryViewModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryViewModel>>>(contentResponse);

                    if (responseCategoryViewModel == null || !responseCategoryViewModel.IsSucceeded)
                    {
                        throw new Exception("API response is null or unsuccessful.");
                    }
                }
                catch (Exception ex)
                {
                    // Hata loglama
                    Console.WriteLine($"Error fetching active categories: {ex.Message}");
                    // Null referans hatalarını önlemek için boş bir liste döndür
                    return new List<CategoryViewModel>();
                }
            }

            return responseCategoryViewModel?.Data ?? new List<CategoryViewModel>();
        }

        public static async Task<List<CategoryViewModel>> GetAllAsync()
        {
            ResponseModel<List<CategoryViewModel>> responseCategoryViewModel = new();
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5200/api/Categories/GetAll");
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                responseCategoryViewModel = JsonConvert.DeserializeObject<ResponseModel<List<CategoryViewModel>>>(contentResponse);
            }
            List<CategoryViewModel> responseCategoryList = responseCategoryViewModel.IsSucceeded ?
                        responseCategoryViewModel.Data : [];
            return responseCategoryList;
        }

        public static async Task<List<SelectListItem>> GetSelectListItemsAsync()
        {
            var categories = await GetActives();
            var result = categories
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            return result;
        }
    }
}