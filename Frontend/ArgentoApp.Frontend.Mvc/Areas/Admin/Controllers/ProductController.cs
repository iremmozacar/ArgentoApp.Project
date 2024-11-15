using ArgentoApp.Frontend.Mvc.Models.Product;
using ArgentoApp.Frontend.Mvc.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArgentoApp.Frontend.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await ProductRepository.GetAllAsync();

                if (!string.IsNullOrEmpty(response.Error))
                {
                    TempData["Error"] = response.Error;
                }

                return View(response.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün listesi görüntülenirken hata oluştu");
                TempData["Error"] = "Ürünler listelenirken bir hata oluştu.";
                return View(new List<ProductViewModel>());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var response = await CategoryRepository.GetSelectListItemsAsync();

                if (!string.IsNullOrEmpty(response.Error))
                {
                    TempData["Error"] = response.Error;
                }

                var model = new ProductCreateViewModel
                {
                    Categories = response.Data ?? new List<SelectListItem>()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün oluşturma formu görüntülenirken hata oluştu");
                TempData["Error"] = "Ürün oluşturma formu yüklenirken bir hata oluştu.";
                return View(new ProductCreateViewModel { Categories = new List<SelectListItem>() });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var product = await ProductRepository.GetByIdAsync(id);
                var categoriesResponse = await CategoryRepository.GetSelectListItemsAsync();

                var model = new ProductEditViewModel
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    ImageUrl = product.ImageUrl,
                    IsActive = product.IsActive,
                    IsHome = product.IsHome,
                    Name = product.Name,
                    Price = product.Price,
                    Properties = product.Properties,
                    Categories = categoriesResponse.Data ?? new List<SelectListItem>()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün düzenleme formu görüntülenirken hata oluştu: {Message}", ex.Message);
                TempData["Error"] = "Ürün düzenleme formu yüklenirken bir hata oluştu.";
                return RedirectToAction("Index");
            }
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

            var categoriesResponse = await CategoryRepository.GetSelectListItemsAsync();
            model.Categories = categoriesResponse.Data ?? new List<SelectListItem>();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isSucceeded = await ProductRepository.DeleteAsync(id);
                if (isSucceeded)
                {
                    TempData["Success"] = "Ürün başarıyla silindi.";
                }
                else
                {
                    TempData["Error"] = "Ürün silinirken bir hata oluştu.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün silinirken hata oluştu: {Message}", ex.Message);
                TempData["Error"] = "Ürün silinirken bir hata oluştu.";
                return RedirectToAction("Index");
            }
        }
    }
}