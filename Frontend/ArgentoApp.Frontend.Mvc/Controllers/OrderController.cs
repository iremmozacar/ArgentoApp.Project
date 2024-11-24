using ArgentoApp.Frontend.Mvc.Data.Entities;
using ArgentoApp.Frontend.Mvc.Models.Order;
using ArgentoApp.Frontend.Mvc.Models.Other;
using ArgentoApp.Frontend.Mvc.Repositories;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Frontend.Mvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotyfService _notyfService;

        public OrderController(UserManager<AppUser> userManager, INotyfService notyfService)
        {
            _userManager = userManager;
            _notyfService = notyfService;
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
                FirstName = "Sezen",
                LastName = "Aksu",
                Address = "Düpedüz Sk. Yamuk yumuk ap. D:12 Beşiktaş",
                City = "İstanbul",
                Email = "sezenaksu@gmail.com",
                PhoneNumber = "5557778844",
                PaymentType = 0,
                UserId = userId
            };
            return View(model);
        }
        [HttpPost]
      public async Task<IActionResult> Checkout(OrderCreateViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);
            var cart = await CartRepository.GetCartAsync(userId);
            List<OrderItemViewModel> orderItems = [];
            foreach (var cartItem in cart.CartItems)
            {
                orderItems.Add(new OrderItemViewModel
                {
                    ProductId = cartItem.ProductId,
                    Price = cartItem.Product.Price,
                    Quantity = cartItem.Quantity
                });
            }
            model.OrderItems = orderItems;
            model.UserId = userId;


            var result = await OrderRepository.AddOrderAsync(model);
            if (!result.IsSucceeded)
            {
                // Error mesajı string'e dönüştürüldü ve null kontrolü eklendi.
                _notyfService.Error(result.Error?.ToString() ?? "Bilinmeyen bir hata oluştu.");
                return View(model);
            }
            await CartRepository.ClearCartAsync(cart.Id);
            _notyfService.Success("Ödeme işlemi başarıyla tamamlandı!");
            _notyfService.Information("Siparişiniz alındı!");
            return RedirectToAction("Index", "Home");
        }

    }
}
