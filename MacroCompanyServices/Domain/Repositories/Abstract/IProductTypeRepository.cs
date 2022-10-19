using MacroCompanyServices.Domain.Entities;

namespace MacroCompanyServices.Domain.Repositories.Abstract
{
    public interface IProductTypeRepository
    {
        IQueryable<ProductType> GetProductTypes();
        ProductType GetProductTypeById(Guid id);
        void SaveProductType(ProductType entity);
        void DeleteProductType(Guid id);
    }
}
