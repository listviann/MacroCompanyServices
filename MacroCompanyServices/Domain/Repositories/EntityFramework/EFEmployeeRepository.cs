using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace MacroCompanyServices.Domain.Repositories.EntityFramework
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly MacroCompanyContext _db;

        public EFEmployeeRepository(MacroCompanyContext db)
        {
            _db = db;
        }

        public IQueryable<Employee> GetEmployees() => _db.Employees.Include(p => p.Products);

        public Employee GetEmployeeById(Guid id) => _db.Employees.Include(p => p.Products).FirstOrDefault(e => e.Id == id);

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
