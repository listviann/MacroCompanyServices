using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace MacroCompanyServices.Domain.Repositories.EntityFramework
{
    public class EFProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationContext _db;

        public EFProductTypeRepository(ApplicationContext db)
        {
            _db = db;
        }

        public IQueryable<ProductType> GetProductTypes() => _db.ProductTypes;

        public ProductType GetProductTypeById(Guid id) => _db.ProductTypes.FirstOrDefault(p => p.Id == id);

        public void SaveProductType(ProductType entity)
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

        public void DeleteProductType(Guid id)
        {
            _db.ProductTypes.Remove(new ProductType { Id = id });
            _db.SaveChanges();
        }
    }
}
