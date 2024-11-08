using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ArgentoApp.Frontend.Mvc.Models;
using Newtonsoft.Json;
using ArgentoApp.Frontend.Mvc.Repositories;

namespace ArgentoApp.Frontend.Mvc.Controllers;

public class HomeController : Controller
{

    public async Task<IActionResult> Index()
    {
        #region Kategorileri API'dan çekiyoruz.
             ResponseModel<List<CategoryModel>>responseCategoryModel = new ();
             using (HttpClient httpClient = new HttpClient())
             {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Categories/GetActives/true");
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                responseCategoryModel=JsonConvert.DeserializeObject<ResponseModel<List<CategoryModel>>>(contentResponse);

             }
             List<CategoryModel>responseCategoryList = responseCategoryModel.IsSucceeded ? responseCategoryModel.Data : [];
        #endregion

     
         ProductsCategories model = new (){
            CategoryList= await CategoryRepository.GetActives(),
            ProductList=await ProductRepository.GetHomesAsync(),
         };

        return View(model);
    }

}
