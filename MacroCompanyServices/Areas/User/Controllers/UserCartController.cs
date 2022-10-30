using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace MacroCompanyServices.Areas.User.Controllers
{
    [Area("User")]
    public class UserCartController : Controller
    {
        private readonly DataManager _dataManager;

        public UserCartController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_dataManager.CartItems.GetCartItems().Include(c => c.Product).Where(c => c.UserId == new Guid(userId)));
        }

        [HttpPost]
        public IActionResult DeleteFromCart(Guid id)
        {
            _dataManager.CartItems.Delete(id);
            return RedirectToAction(nameof(UserCartController.Index), nameof(UserCartController).CutController());
        }


    }
}
