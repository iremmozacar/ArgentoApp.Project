using ArgentoApp.Frontend.Mvc.Models.Product;
using ArgentoApp.Frontend.Mvc.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ProductViewModel product = await ProductRepository.GetByIdAsync(id);
            ProductEditViewModel model = new()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl,
                IsActive = product.IsActive,
                IsHome = product.IsHome,
                Name = product.Name,
                Price = product.Price,
                Properties = product.Properties,
                Categories = await CategoryRepository.GetSelectListItemsAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isSucceeded = await ProductRepository.UpdateAsync(model);
                if (isSucceeded)
                {
                    return RedirectToAction("Index");
                }
            }
            model.Categories = await CategoryRepository.GetSelectListItemsAsync();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var isSucceeded = await ProductRepository.DeleteAsync(id);
            if (isSucceeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var product = await ProductRepository.UpdateIsActiveAsync(id);
            return Json(product.IsHome);
        }

        public async Task<IActionResult> UpdateIsHome(int id)
        {
            var isSucceeded = await ProductRepository.UpdateIsHomeAsync(id);
            string result = "{isSucceeded: " + isSucceeded + "}";
            return Json(result);
        }
    }
}
