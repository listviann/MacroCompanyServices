using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Domain;
using MacroCompanyServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MacroCompanyServices.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataManager _dataManager;

        public ProductsController(DataManager dataManager)
        {
            _dataManager = dataManager;
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
    }
}
