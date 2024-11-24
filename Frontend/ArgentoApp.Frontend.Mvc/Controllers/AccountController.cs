using ArgentoApp.Frontend.Mvc.Data.Entities;
using ArgentoApp.Frontend.Mvc.Models.Identity;
using ArgentoApp.Frontend.Mvc.Repositories;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Frontend.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly INotyfService _notyfService;

        public AccountController(UserManager<AppUser> userManager, INotyfService notyfService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _notyfService = notyfService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);
            UserProfileViewModel model = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };
            model.Orders = await OrderRepository.GetOrdersByUserIdAsync(userId);
            // model.Orders = model.Orders.OrderByDescending(o => o.OrderDate).ToList();
            var cart = await CartRepository.GetCartAsync(userId);
            ViewBag.CountOfItems = cart.CountOfItem;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            LoginViewModel loginViewModel = new() { ReturnUrl = returnUrl };
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            model.ReturnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                // Kullanıcı var mı yok mu kontrolü
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    _notyfService.Error("Böyle bir kullanıcı yok!");
                    return View(model);
                }
                // Kullanıcı emaili onaylı mı değil mi kontrolü
                bool isApproved = await _userManager.IsEmailConfirmedAsync(user);
                if (!isApproved)
                {
                    _notyfService.Warning("Email onaylı değil!");
                    return View(model);
                }
                // Login olma işlemi
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                if (!result.Succeeded)
                {
                    _notyfService.Error("Hatalı parola!");
                    return View(model);
                }
                //EĞER BURAYA KADAR GELMİŞSE ARTIK LOGIN OLMUŞ DEMEKTİR!
                return Redirect(model.ReturnUrl);
            }
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            _notyfService.Warning("Bu alana girmeye yetkiniz yok!");
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public async Task<IActionResult> UpdateProfile(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                // user.UserName = model.UserName;
                await _userManager.UpdateAsync(user);
                _notyfService.Success("Güncelleme başarıyla tamamlandı!");
                return RedirectToAction("Index");
            }
            _notyfService.Error("Bir hata oluştu");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }
    }
}
