using ArgentoApp.Frontend.Mvc.Models.Other; // ContentDataModel'in bulunduğu namespace
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Frontend.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            // ContentDataModel nesnesini oluşturuyoruz
            var contentDataModel = new ContentDataModel
            {
                PageHeader = "Ana Sayfa Başlığı", // Sayfa başlığını burada belirtiyoruz
                ShowButton = true, // Butonun görünmesi gerektiğini belirtiyoruz
                ButtonTitle = "Butona Tıkla", // Butonun başlığını belirtiyoruz
                ButtonLink = "/admin/products" // Butonun yönlendireceği linki belirtiyoruz
            };

            // contentDataModel'i doğrudan View'a gönderiyoruz
            return View(contentDataModel);
        }
    }
}