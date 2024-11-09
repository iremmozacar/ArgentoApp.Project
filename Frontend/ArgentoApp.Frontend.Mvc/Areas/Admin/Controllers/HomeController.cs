using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Frontend.Mvc.Areas.Admin.Controllers
{
    
    
    [Area("Admin")]
        public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

    }
}
