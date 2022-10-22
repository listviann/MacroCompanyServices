using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MacroCompanyServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductItemsController : Controller
    {
        private readonly DataManager _dataManager;

        public ProductItemsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.Products.GetProducts());
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
                _dataManager.Products.SaveProduct(model);
                return RedirectToAction(nameof(ProductItemsController.Index), nameof(ProductItemsController).CutController());
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _dataManager.Products.DeleteProduct(id);
            return RedirectToAction(nameof(ProductItemsController.Index), nameof(ProductItemsController).CutController());
        }
    }
}
