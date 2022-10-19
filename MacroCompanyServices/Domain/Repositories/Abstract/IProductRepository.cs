using MacroCompanyServices.Domain.Entities;

namespace MacroCompanyServices.Domain.Repositories.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> GetProducts();
        Product GetProductById(Guid id);
        void SaveProduct(Product entity);
        void DeleteProduct(Guid id);
    }
}
