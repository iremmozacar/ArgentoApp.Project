using ArgentoApp.Frontend.Mvc.Models.Other; // ContentDataModel'in bulunduğu namespace
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Frontend.Mvc.Areas.Admin.Controllers

{
    [Area("Admin")]
    // [Authorize(Roles = "Super Admin, Admin")] 
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
