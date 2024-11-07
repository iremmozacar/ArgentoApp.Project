using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ArgentoApp.Frontend.Mvc.Models;

namespace ArgentoApp.Frontend.Mvc.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

}
