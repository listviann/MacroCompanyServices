using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using MacroCompanyServices.Areas.User.Models;
using MacroCompanyServices.Models;

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

        public IActionResult Index(string name, Guid productType, int page = 1, CartItemsSortState sortOrder = CartItemsSortState.ProductNameAsc)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IQueryable<CartItem> cartItems = _dataManager.CartItems.GetCartItems().Include(c => c.Product).Include(c => c.Product!.ProductType).Where(c => c.UserId == new Guid(userId));

            int pageSize = 3;

            if (!string.IsNullOrEmpty(name))
            {
                cartItems = cartItems.Where(c => c.Product!.ProductName!.Contains(name));
            }

            cartItems = sortOrder switch
            {
                CartItemsSortState.ProductNameDesc => cartItems.OrderByDescending(c => c.Product!.ProductName),
                _ => cartItems.OrderBy(c => c.Product!.ProductName),
            };

            var count = cartItems.Count();
            var items = cartItems.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            CartItemsIndexViewModel viewModel = new CartItemsIndexViewModel(items,
                new PageViewModel(count, page, pageSize),
                new CartItemsFilterViewModel(name),
                new CartItemsSortViewModel(sortOrder));

            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteFromCart(Guid id)
        {
            _dataManager.CartItems.Delete(id);
            return RedirectToAction(nameof(UserCartController.Index), nameof(UserCartController).CutController());
        }
    }
}
