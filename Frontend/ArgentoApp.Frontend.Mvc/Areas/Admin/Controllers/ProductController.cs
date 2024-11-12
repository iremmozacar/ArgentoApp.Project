using ArgentoApp.Frontend.Mvc.Models.Product;
using ArgentoApp.Frontend.Mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Frontend.Mvc.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class ProductController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var products = await ProductRepository.GetAllAsync();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ProductCreateViewModel
            {
                Categories = await CategoryRepository.GetSelectListItemsAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isSucceeded = await ProductRepository.CreateAsync(model);
                if (isSucceeded)
                {
                    return RedirectToAction("Index");
                }

            }
            model.Categories = await CategoryRepository.GetSelectListItemsAsync();
            return View(model);
        }
    }
}

