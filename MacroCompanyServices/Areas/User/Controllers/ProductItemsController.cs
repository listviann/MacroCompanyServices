using MacroCompanyServices.Areas.Admin.Controllers;
using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Models;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace MacroCompanyServices.Areas.User.Controllers
{
    [Area("User")]
    public class ProductItemsController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ProductItemsController(DataManager dataManager, UserManager<IdentityUser> userManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
        }

        public async  Task<IActionResult> Index(string name, Guid productType, Guid employee,
            int page = 1, ProductsSortState sortOrder = ProductsSortState.ProductNameAsc)
        {
            int pageSize = 3;

            IQueryable<Product> products = _dataManager.Products.GetProducts().Include(t => t.ProductType).Include(e => e.Employee);

            if (productType != default)
            {
                products = products.Where(p => p.ProductTypeId == productType);
            }

            if (employee != default)
            {
                products = products.Where(p => p.EmployeeId == employee);
            }

            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.ProductName!.Contains(name));
            }

            products = sortOrder switch
            {
                ProductsSortState.ProductNameDesc => products.OrderByDescending(p => p.ProductName),
                ProductsSortState.ProductPriceAsc => products.OrderBy(p => p.ProductPrice),
                ProductsSortState.ProductPriceDesc => products.OrderByDescending(p => p.ProductPrice),
                ProductsSortState.ProductTypeNameAsc => products.OrderBy(p => p.ProductType!.Name),
                ProductsSortState.ProductTypeNameDesc => products.OrderByDescending(p => p.ProductType!.Name),
                ProductsSortState.DateAddedAsc => products.OrderBy(p => p.DateAdded),
                ProductsSortState.DateAddedDesc => products.OrderByDescending(p => p.DateAdded),
                ProductsSortState.EmployeeNameAsc => products.OrderBy(p => p.Employee!.Name),
                ProductsSortState.EmployeeNameDesc => products.OrderByDescending(p => p.Employee!.Name),
                _ => products.OrderBy(p => p.ProductName),
            };

            var count = products.Count();
            var items = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ProductsIndexViewModel viewModel = new ProductsIndexViewModel(items,
                new PageViewModel(count, page, pageSize),
                new ProductsFilterViewModel(_dataManager.ProductTypes.GetProductTypes().ToList(),
                    _dataManager.Employees.GetEmployees().ToList(),
                    employee,
                    productType,
                    name),
                new ProductsSortViewModel(sortOrder));

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // get id of the current user

            ViewBag.userId = userId;
            Debug.WriteLine(userId);

            return View(viewModel);
        }

        public IActionResult AddToCart(Guid prodId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // get id of the current user
            ViewBag.userId = new Guid(userId);
            Debug.WriteLine(userId);

            _dataManager.CartItems.Save(prodId, new Guid(userId));
            return RedirectToAction(nameof(ProductItemsController.Index), nameof(ProductItemsController).CutController());
        }
    }
}
