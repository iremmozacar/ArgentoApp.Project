using ArgentoApp.Frontend.Mvc.Models.Product;
using ArgentoApp.Frontend.Mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Frontend.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
            var products = await ProductRepository.GetAllAsync();
            return View(products);
        }


          public async Task<IActionResult> Create()
            {
                var model = new ProductCreateViewModel
                {
                    Categories = await CategoryRepository.GetSelectListItemsAsync()
                };
                return View(model);
            }
    }
}

