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
                // Kullanıcı var mı kontrolü
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    _notyfService.Error("Kullanıcı adı veya şifre hatalı.");
                    return View(model);
                }

                // Kullanıcı emaili onaylı mı kontrolü
                bool isApproved = await _userManager.IsEmailConfirmedAsync(user);
                if (!isApproved)
                {
                    _notyfService.Warning("Hesabınızın onaylanması bekleniyor. Lütfen e-posta adresinizi kontrol edin.");
                    return View(model);
                }

                // Giriş işlemi
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                if (!result.Succeeded)
                {
                    _notyfService.Error("Giriş yaparken bir hata oluştu. Lütfen şifrenizi kontrol edin.");
                    return View(model);
                }

                // ReturnUrl kontrolü ve yönlendirme
                if (Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
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