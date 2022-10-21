using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Mvc;

namespace MacroCompanyServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeItemsController : Controller
    {
        private readonly DataManager _dataManager;

        public ProductTypeItemsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.ProductTypes.GetProductTypes());
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
                return RedirectToAction(nameof(ProductTypeItemsController.Index), nameof(ProductTypeItemsController).CutController());
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _dataManager.ProductTypes.DeleteProductType(id);
            return RedirectToAction(nameof(ProductTypeItemsController.Index), nameof(ProductTypeItemsController).CutController());
        }
    }
}
