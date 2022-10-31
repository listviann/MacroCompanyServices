using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MacroCompanyServices.Models;
using MacroCompanyServices.Service;
using MacroCompanyServices.Loggers;
using System.Security.Claims;

namespace MacroCompanyServices.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, "ordinary_user");
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    _logger.LogDebug($"A new user {user.Id} - {user.UserName} registerd at {DateTime.Now}");
                    return Redirect(returnUrl ?? "/");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync
                        (user, model.Password, model.RememberMe, false);

                    if (signInResult.Succeeded)
                    {
                        _logger.LogDebug($"User {user.Id} - {user.UserName} logged in at {DateTime.Now}");
                        return Redirect(returnUrl ?? "/");
                    }
                }

                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Incorrect username or passord");
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _signInManager.SignOutAsync();
            _logger.LogDebug($"User with ID: {userId} logged out at {DateTime.Now}");

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
