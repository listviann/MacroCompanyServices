using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Domain;
using MacroCompanyServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MacroCompanyServices.Service;
using System.Security.Claims;

namespace MacroCompanyServices.Areas.User.Controllers
{
    [Area("User")]
    public class EmployeeItemsController : Controller
    {
        private readonly DataManager _dataManager;
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

        public IActionResult Info(Guid id)
        {
            IQueryable<Employee> employees = _dataManager.Employees.GetEmployees().Include(p => p.Products);

            if (id != default)
            {
                //Employee? employee = _dataManager.Employees.GetEmployeeById(id);
                Employee? employee = employees.FirstOrDefault(e => e.Id == id);
                if (employee != null) return View(employee);
            }

            return NotFound();
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
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _dataManager.Employees.SaveEmployee(model);
                _logger.LogInformation($"User with ID: {userId} added or modified an employee record with ID: {model.Id}");
                return RedirectToAction(nameof(EmployeeItemsController.Index), nameof(EmployeeItemsController).CutController());
            }

            return View(model);
        }
    }
}
