using ArgentoApp.Frontend.Mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Frontend.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await ProductRepository.GetByIdAsync(id);
            return View(product);
        }

    }
}
