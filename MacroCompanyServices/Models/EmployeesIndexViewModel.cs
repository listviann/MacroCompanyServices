using MacroCompanyServices.Domain.Entities;

namespace MacroCompanyServices.Models
{
    public class EmployeesIndexViewModel
    {
        public IEnumerable<Employee> Employees { get; }
        public PageViewModel PageViewModel { get; }
        public EmployeesFilterViewModel FilterViewModel { get; }
        public EmployeesSortViewModel SortViewModel { get; }

        public EmployeesIndexViewModel(IEnumerable<Employee> employees, PageViewModel pageViewModel,
            EmployeesFilterViewModel filterViewModel, EmployeesSortViewModel sortViewModel)
        {
            Employees = employees;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
        }
    }
}
