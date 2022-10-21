using MacroCompanyServices.Controllers;
using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Mvc;

namespace MacroCompanyServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeItemsController : Controller
    {
        public readonly DataManager _dataManager;

        public EmployeeItemsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.Employees.GetEmployees());
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Employee() : _dataManager.Employees.GetEmployeeById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                _dataManager.Employees.SaveEmployee(model);
                return RedirectToAction(nameof(EmployeeItemsController.Index), nameof(EmployeeItemsController).CutController());
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _dataManager.Employees.DeleteEmployee(id);
            return RedirectToAction(nameof(EmployeeItemsController.Index), nameof(EmployeeItemsController).CutController());
        }
    }
}
