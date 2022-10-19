using MacroCompanyServices.Domain.Entities;

namespace MacroCompanyServices.Domain.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetEmployees();
        Employee GetEmployeeById(Guid id);
        void SaveEmployee(Employee entity);
        void DeleteEmployee(Guid id);
    }
}
