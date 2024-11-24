using ArgentoApp.Frontend.Mvc.Data.Entities;
using ArgentoApp.Frontend.Mvc.Models.Identity;
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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            LoginViewModel loginViewModel = new() { ReturnUrl = returnUrl };
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
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
                return Redirect(model.ReturnUrl ?? "~/");
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
    }
}
