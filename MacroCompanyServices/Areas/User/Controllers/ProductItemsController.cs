using MacroCompanyServices.Areas.Admin.Controllers;
using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Models;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ILogger<ProductItemsController> _logger;

        public ProductItemsController(DataManager dataManager, UserManager<IdentityUser> userManager, ILogger<ProductItemsController> logger)
        {
            _dataManager = dataManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index(string name, Guid productType, Guid employee,
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

        public IActionResult Info(Guid id)
        {
            if (id != default)
            {
                IQueryable<Product> products = _dataManager.Products.GetProducts().Include(p => p.ProductType).Include(p => p.Employee);
                Product? product = products.FirstOrDefault(p => p.Id == id);
                if (product != null) return View(product);
            }

            return NotFound();
        }

        public IActionResult Edit(Guid id)
        {
            List<ProductType> productTypes = _dataManager.ProductTypes.GetProductTypes().ToList();
            ViewBag.ProductTypes = new SelectList(productTypes, "Id", "Name");

            List<Employee> employees = _dataManager.Employees.GetEmployees().ToList();
            ViewBag.Employees = new SelectList(employees, "Id", "Name");

            var entity = id == default ? new Product() : _dataManager.Products.GetProductById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _dataManager.Products.SaveProduct(model);
                _logger.LogDebug($"User with ID: {userId} added or modified a product record with ID: {model.Id}");
                return RedirectToAction(nameof(ProductItemsController.Index), nameof(ProductItemsController).CutController());
            }

            return View(model);
        }

        public IActionResult AddToCart(Guid prodId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // get id of the current user
            ViewBag.userId = new Guid(userId);
            Debug.WriteLine(userId);

            _dataManager.CartItems.Save(prodId, new Guid(userId));
            _logger.LogDebug($"User with ID: {userId} added an item with ID: {prodId} to the products cart");
            return RedirectToAction(nameof(ProductItemsController.Index), nameof(ProductItemsController).CutController());
        }
    }
}
