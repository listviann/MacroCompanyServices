using MacroCompanyServices.Areas.User.Models;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MacroCompanyServices.Areas.User.Controllers
{
    [Area("User")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
                user.UserName = model.UserName;
                var result = await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(UserProfileController.Index), nameof(UserProfileController).CutController());
            }
            
            return View(model);
        }
    }
}
