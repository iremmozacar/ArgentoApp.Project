using ArgentoApp.Frontend.Mvc.Data.Entities;
using ArgentoApp.Frontend.Mvc.Models.Other;
using ArgentoApp.Frontend.Mvc.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Frontend.Mvc.Controllers
{

    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public OrderController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);
            var cart = await CartRepository.GetCartAsync(userId);
            OrderCreateViewModel model = new()
            {
                Cart = cart,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderCreateViewModel model)
        {
            return View();
        }

    }
}
