using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MacroCompanyServices.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DataManager _dataManager;

        public EmployeesController(DataManager dataManager)
        {
            _dataManager = dataManager;
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
            if (id != default)
            {
                Employee? employee = _dataManager.Employees.GetEmployeeById(id);
                if (employee != null) return View(employee);
            }

            return NotFound();
        }
    }
}
