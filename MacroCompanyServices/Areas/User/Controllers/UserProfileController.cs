using MacroCompanyServices.Areas.User.Models;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;
using System.Security.Claims;

namespace MacroCompanyServices.Areas.User.Controllers
{
    [Area("User")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<UserProfileController> _logger;

        public UserProfileController(UserManager<IdentityUser> userManager, ILogger<UserProfileController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);

            ViewBag.userId = new Guid(userId);
            ViewBag.userName = userName;
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var model = new EditUserViewModel() { Id = new Guid(user.Id) };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());

            if (ModelState.IsValid)
            {
                string temp = user.UserName;
                user.UserName = model.UserName;
                var result = await _userManager.UpdateAsync(user);

                _logger.LogDebug($"User with ID: {user.Id} changed his username from {temp} to {user.UserName}");
                return RedirectToAction(nameof(UserProfileController.Index), nameof(UserProfileController).CutController());
            }
            
            return View(model);
        }

        public IActionResult ChangePassword()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Debug.WriteLine(userId);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                _logger.LogDebug($"User with ID: {userId} changed password");
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }

            return View(model);
        }
    }
}
