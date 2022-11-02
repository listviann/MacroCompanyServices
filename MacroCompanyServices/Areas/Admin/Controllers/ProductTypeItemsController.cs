using MacroCompanyServices.Areas.Admin.Models;
using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Service;
using MacroCompanyServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace MacroCompanyServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeItemsController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly ILogger<ProductTypeItemsController> _logger;

        public ProductTypeItemsController(DataManager dataManager, ILogger<ProductTypeItemsController> logger)
        {
            _dataManager = dataManager;
            _logger = logger;
        }

        public IActionResult Index(string name, int page = 1, ProductTypeSortState sortOrder = ProductTypeSortState.ProductTypeNameAsc)
        {
            int pageSize = 3;
            IQueryable<ProductType> productTypes = _dataManager.ProductTypes.GetProductTypes();

            if (!string.IsNullOrEmpty(name))
            {
                productTypes = productTypes.Where(p => p.Name!.Contains(name));
            }

            productTypes = sortOrder switch
            {
                ProductTypeSortState.ProductTypeNameDesc => productTypes.OrderByDescending(p => p.Name),
                _ => productTypes.OrderBy(p => p.Name),
            };

            var count = productTypes.Count();
            var items = productTypes.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ProductTypesIndexViewModel viewModel = new ProductTypesIndexViewModel(items, 
                new PageViewModel(count, page, pageSize),
                new ProductTypesFilterViewModel(name),
                new ProductTypesSortViewModel(sortOrder));

            return View(viewModel);
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new ProductType() : _dataManager.ProductTypes.GetProductTypeById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(ProductType model)
        {
            if (ModelState.IsValid)
            {
                _dataManager.ProductTypes.SaveProductType(model);
                _logger.LogInformation($"The administrator added or modified an product type with ID: {model.Id}");
                return RedirectToAction(nameof(ProductTypeItemsController.Index), nameof(ProductTypeItemsController).CutController());
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _dataManager.ProductTypes.DeleteProductType(id);
            _logger.LogInformation($"The administrator deleted a product type with ID: {id}");
            return RedirectToAction(nameof(ProductTypeItemsController.Index), nameof(ProductTypeItemsController).CutController());
        }
    }
}
