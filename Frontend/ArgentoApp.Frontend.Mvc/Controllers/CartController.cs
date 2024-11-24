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

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(int cartItemId, int quantity)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);
            ReturnChangeQuantityModel model = await CartRepository.ChangeQuantityAsync(cartItemId, quantity, userId);
            // var modelJson = JsonConvert.SerializeObject(model);
            return Json(model);
        }

        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var isSucceeded = await CartRepository.DeleteCartItemAsync(id);
            if (!isSucceeded)
            {
                _notyfService.Error("Bir hata oluştu");
            }
            _notyfService.Success("Ürün sepetinizden başarıyla kaldırıldı");
            return RedirectToAction("Index");

        }

    }
    }
