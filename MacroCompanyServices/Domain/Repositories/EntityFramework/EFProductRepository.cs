using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace MacroCompanyServices.Domain.Repositories.EntityFramework
{
    public class EFProductRepository : IProductRepository
    {
        private MacroCompanyContext _db;

        public EFProductRepository(MacroCompanyContext db)
        {
            _db = db;
        }

        public IQueryable<Product> GetProducts() => _db.Products.Include(p => p.ProductType).Include(p => p.Employee);

        public Product GetProductById(Guid id) => _db.Products.Include(p => p.ProductType).Include(p => p.Employee).FirstOrDefault(p => p.Id == id);

        public void SaveProduct(Product entity)
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

        public void DeleteProduct(Guid id)
        {
            _db.Remove(new Product { Id = id });
            _db.SaveChanges();
        }
    }
}
