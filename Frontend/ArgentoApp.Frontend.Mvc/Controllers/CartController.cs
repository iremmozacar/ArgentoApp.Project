using ArgentoApp.Frontend.Mvc.Data.Entities;
using ArgentoApp.Frontend.Mvc.Models.Cart;
using ArgentoApp.Frontend.Mvc.Repositories;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Frontend.Mvc.Controllers
{
 
        public class CartController : Controller
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly INotyfService _notyfService;

            public CartController(UserManager<AppUser> userManager, INotyfService notyfService)
            {
                _userManager = userManager;
                _notyfService = notyfService;
            }

            public async Task<IActionResult> Index()
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var userId = await _userManager.GetUserIdAsync(user);
                var cart = await CartRepository.GetCartAsync(userId);
                return View(cart);
            }

            [Authorize]
            public async Task<IActionResult> AddToCart(AddToCartViewModel model)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var userId = await _userManager.GetUserIdAsync(user);
                model.UserId = userId;
                var isSucceeded = await CartRepository.AddToCartAsync(model);
                if (!isSucceeded)
                {
                    _notyfService.Error("Bir hata oluştu, ürün sepete eklenemedi!");
                    return Redirect("~/");
                }
                return RedirectToAction("Index");
            }

        }
    }
