using MacroCompanyServices.Controllers;
using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Models;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MacroCompanyServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeItemsController : Controller
    {
        public readonly DataManager _dataManager;
        private readonly ILogger<EmployeeItemsController> _logger;

        public EmployeeItemsController(DataManager dataManager, ILogger<EmployeeItemsController> logger)
        {
            _dataManager = dataManager;
            _logger = logger;
        }

        public IActionResult Index(string name, string email, int page = 1, EmployeesSortState sortOrder = EmployeesSortState.EmployeeNameAsc)
        {
            int pageSize = 3;

            IQueryable<Employee> employees = _dataManager.Employees.GetEmployees();

            if (!string.IsNullOrEmpty(name))
            {
                employees = employees.Where(e => e.Name!.Contains(name));
            }

            if (!string.IsNullOrEmpty(email))
            {
                employees = employees.Where(e => e.Email!.Contains(email));
            }

            employees = sortOrder switch
            {
                EmployeesSortState.EmployeeNameDesc => employees.OrderByDescending(e => e.Name),
                EmployeesSortState.EmployeeEmailAsc => employees.OrderBy(e => e.Email),
                EmployeesSortState.EmployeeEmailDesc => employees.OrderByDescending(e => e.Email),
                EmployeesSortState.EmployeePhoneNumberAsc => employees.OrderBy(e => e.PhoneNumber),
                EmployeesSortState.EmployeePhoneNumberDesc => employees.OrderByDescending(e => e.PhoneNumber),
                EmployeesSortState.EmployeeSalaryAsc => employees.OrderBy(e => e.Salary),
                EmployeesSortState.EmployeeSalaryDesc => employees.OrderByDescending(e => e.Salary),
                EmployeesSortState.EmployeeBirthDateAsc => employees.OrderBy(e => e.BirthDate),
                EmployeesSortState.EmployeeBirthDateDesc => employees.OrderByDescending(e => e.BirthDate),
                EmployeesSortState.EmployeePositionAsc => employees.OrderBy(e => e.Position),
                EmployeesSortState.EmployeePositionDesc => employees.OrderByDescending(e => e.Position),
                EmployeesSortState.DateAddedAsc => employees.OrderBy(e => e.DateAdded),
                EmployeesSortState.DateAddedDesc => employees.OrderByDescending(e => e.DateAdded),
                _ => employees.OrderBy(e => e.Name),
            };
            var count = employees.Count();
            var items = employees.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            EmployeesIndexViewModel viewModel = new EmployeesIndexViewModel(items,
                new PageViewModel(count, page, pageSize),
                new EmployeesFilterViewModel(name, email),
                new EmployeesSortViewModel(sortOrder));

            return View(viewModel);
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
                _logger.LogDebug($"The administrator added or modified an employee with ID: {model.Id}");
                return RedirectToAction(nameof(EmployeeItemsController.Index), nameof(EmployeeItemsController).CutController());
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _dataManager.Employees.DeleteEmployee(id);
            _logger.LogDebug($"The administrator deleted an employee with ID: {id}");
            return RedirectToAction(nameof(EmployeeItemsController.Index), nameof(EmployeeItemsController).CutController());
        }
    }
}
