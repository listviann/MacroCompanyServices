using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace MacroCompanyServices.Domain.Repositories.EntityFramework
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _db;

        public EFEmployeeRepository(ApplicationContext db)
        {
            _db = db;
        }

        public IQueryable<Employee> GetEmployees() => _db.Employees;

        public Employee GetEmployeeById(Guid id) => _db.Employees.FirstOrDefault(e => e.Id == id);

        public void SaveEmployee(Employee entity)
        {
            if (entity.Id == default)
            {
                _db.Entry(entity).State = EntityState.Added;
            }
            else
            {
                _db.Entry(entity).State = EntityState.Modified;
            }

            _db.SaveChanges();
        }

        public void DeleteEmployee(Guid id)
        {
            _db.Employees.Remove(new Employee { Id = id });
            _db.SaveChanges();
        }
    }
}
